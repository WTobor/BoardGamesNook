import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Location } from "@angular/common";

import { GamerService } from "../gamers/gamer.service";
import { BoardGameService } from "../boardGames/boardGame.service";
import { Gamer } from "../gamers/gamer";
import { BoardGame } from "../boardGames/boardGame";
import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";
import { Common } from "./../Common";
import { GameTableService } from "../gameTables/gameTable.service";

@Component({
    selector: "gameResult-add",
    templateUrl: "./src/gameResults/gameResult-add.component.html",
    providers: [BoardGameService, GamerService, GameTableService]
})
export class GameResultAddComponent implements OnInit {
    gameResult = new GameResult();
    availableBoardGames: BoardGame[];
    availableGamers: Gamer[];

    currentGamerNickname: string;

    selectedGamer: Gamer;
    selectedBoardGame: BoardGame;

    constructor(
        private gameResultService: GameResultService,
        private boardGameService: BoardGameService,
        private gamerService: GamerService,
        private location: Location,
        private router: Router
    ) {
    }

    ngOnInit() {
        this.gameResultService.getGameResult(0)
            .subscribe((gameResult: GameResult) => {
                this.gameResult = gameResult;
            });

        this.boardGameService.getBoardGames().subscribe(
            response => {
                this.availableBoardGames = response;
            }
        );
        this.gamerService.getGamers().subscribe(
            response => {
                this.availableGamers = response;
            }
        );
        this.gamerService.getCurrentGamerNickname().subscribe(nickname => {
            this.currentGamerNickname = nickname;
        });
    }

    selectBoardGame(value: BoardGame): void {
        this.gameResult.BoardGameId = value.Id;
        this.gameResult.BoardGameName = value.Name;
    }

    selectGamer(id: string, value: string): void {
        this.gameResult.GamerId = id;
        this.gameResult.GamerNickname = value;
    }

    onSubmit(submittedForm) {
        if (submittedForm.invalid) {
            return;
        }
        this.add(submittedForm.value.points, submittedForm.value.place, submittedForm.value.playersNumber);
    }

    add(points: number, place: number, playersNumber: number): void {
        this.gameResult.GamerId = this.selectedGamer.Id;
        this.gameResult.GamerNickname = this.selectedGamer.Nickname;
        this.gameResult.BoardGameId = this.selectedBoardGame.Id;
        this.gameResult.BoardGameName = this.selectedBoardGame.Name;

        this.gameResult.Points = points;
        this.gameResult.Place = place;
        this.gameResult.PlayersNumber = playersNumber;

        var loc = this.location;
        this.gameResultService.create(this.gameResult)
            .subscribe(errorMessage => new Common(loc).showErrorOrGoBack(errorMessage));
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }
}