import { GamerService } from "../gamers/gamer.service";
import { BoardGameService } from "../boardGames/boardGame.service";
import { Gamer } from "../gamers/gamer";
import { BoardGame } from "../boardGames/boardGame";
import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router, Params } from "@angular/router";
import { Location } from "@angular/common";

import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";

import { Common } from "./../Common";
import { GameTableService } from "../gameTables/gameTable.service";
import { GameTable } from "../gameTables/gameTable";
import { TableBoardGame } from "../gameTables/tableBoardGame";

@Component({
    selector: "gameResult-add",
    templateUrl: "./src/gameResults/gameResult-add.component.html",
    providers: [BoardGameService, GamerService, GameTableService]
})
export class GameResultAddComponent implements OnInit {
    gameResult: GameResult;
    gameResults: GameResult[];
    availableBoardGames: BoardGame[];
    availableGamers: Gamer[];
    selectedBoardGame: BoardGame;
    selectedBoardGameId: number;
    selectedGamerId: string;
    currentGamerNickname: string;

    constructor(
        private gameResultService: GameResultService,
        private boardGameService: BoardGameService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location,
        private router: Router
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap(() => this.gameResultService.getGameResult(0))
            .subscribe((gameResult: GameResult) => {
                this.gameResult = gameResult;
            });

        this.boardGameService.getBoardGames().then(
            response => {
                this.availableBoardGames = response;
            }
        );
        this.gamerService.getGamers().then(
            response => {
                this.availableGamers = response;
            }
        );
        this.gamerService.getCurrentGamerNickname().then(nickname => {
            this.currentGamerNickname = nickname;
        });
    }

    selectBoardGame(value: number): void {
        this.selectedBoardGameId = Number(value);
    }

    selectGamer(value): void {
        this.selectedGamerId = value;
    }

    onSubmit(submittedForm) {
        if (submittedForm.invalid) {
            return;
        }
        this.add(submittedForm.value.points, submittedForm.value.place, submittedForm.value.playersNumber);
    }

    add(points: number, place: number, playersNumber: number): void {
        this.gameResult = new GameResult;
        this.gameResult.BoardGameId = this.selectedBoardGameId;
        this.gameResult.GamerId = this.selectedGamerId;
        this.gameResult.Points = points;
        this.gameResult.Place = place;
        this.gameResult.PlayersNumber = playersNumber;

        this.gameResultService.create(this.gameResult)
            .then(errorMessage => {
                new Common(null, this.router).showErrorOrReturn(errorMessage);
                this.router.navigate([""]);
                window.location.reload();
            });
    }
}