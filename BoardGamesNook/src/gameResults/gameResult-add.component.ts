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

@Component({
    selector: "gameResult-add",
    templateUrl: "./src/gameResults/gameResult-add.component.html",
    providers: [BoardGameService, GamerService]
})
export class GameResultAddComponent implements OnInit {
    gameResult: GameResult;
    availableBoardGames: BoardGame[];
    availableGamers: Gamer[];
    selectedBoardGame: BoardGame;

    constructor(
        private gameResultService: GameResultService,
        private boardGameService: BoardGameService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location,
        private router: Router
    ) { }

    ngOnInit() {
        debugger
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
    }


    add(boardGameId: number, gamerId: string, points: number, place: number): void {
        this.gameResult = new GameResult;
        this.gameResult.BoardGameId = boardGameId;
        this.gameResult.GamerId = gamerId;
        this.gameResult.Points = points;
        this.gameResult.Place = place;

        this.gameResultService.create(this.gameResult)
            .then(errorMessage => {
                new Common(null, this.router).showErrorOrReturn(errorMessage);
                this.router.navigate([""]);
                window.location.reload();
            });
    }
}