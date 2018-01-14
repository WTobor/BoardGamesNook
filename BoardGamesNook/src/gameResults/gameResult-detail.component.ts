import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";

import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";

import { Common } from "./../Common";
import { BoardGame } from "../boardGames/boardGame";
import { Gamer } from "../gamers/gamer";
import { BoardGameService } from "../boardGames/boardGame.service";
import { GamerService } from "../gamers/gamer.service";

@Component({
    selector: "gameResult-detail",
    templateUrl: "./src/gameResults/gameResult-detail.component.html",
    providers: [BoardGameService, GamerService]
})
export class GameResultDetailComponent implements OnInit {
    gameResult: GameResult;
    isCurrentResult: boolean = false;
    availableBoardGames: BoardGame[];
    availableGamers: Gamer[];

    constructor(
        private gameResultService: GameResultService,
        private boardGameService: BoardGameService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gameResultService.getByNickname(params["nickname"]))
            .subscribe((gameResult: GameResult) => {
                this.gameResult = gameResult;
            });

        this.boardGameService.getBoardGames().then(
            (boardGames: BoardGame[]) => {
                this.availableBoardGames = boardGames;
            }
        );

        this.gamerService.getGamers().then(
            (gamers: Gamer[]) => {
                this.availableGamers = gamers;
            }
        );
    }

    save(): void {
        var loc = this.location;
        this.gameResultService.update(this.gameResult)
            .then(errorMessage => {
                if (this.isCurrentResult) {
                    new Common().showErrorOrReturn(errorMessage);
                }
                else {
                    new Common(loc).showErrorOrGoBack(errorMessage);
                }
            });
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}