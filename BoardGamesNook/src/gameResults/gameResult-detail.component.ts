import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";

import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";

import { Common } from "./../Common";
import { BoardGameService } from "../boardGames/boardGame.service";
import { GamerService } from "../gamers/gamer.service";

@Component({
    selector: "gameResult-detail",
    templateUrl: "./src/gameResults/gameResult-detail.component.html",
    providers: [BoardGameService, GamerService]
})
export class GameResultDetailComponent implements OnInit {
    gameResult: GameResult;
    canChange: boolean = false;

    constructor(
        private gameResultService: GameResultService,
        private boardGameService: BoardGameService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gameResultService.getGameResult(params["id"]))
            .subscribe((gameResult: GameResult) => {
                this.gameResult = gameResult;
                this.gamerService.getCurrentGamerNickname().then(nickname => {
                    if (nickname === this.gameResult.CreatedGamerNickname) {
                        this.canChange = true;
                    }
                });
            });

    }

    onSubmit(submittedForm) {
        if (submittedForm.invalid) {
            return;
        }
        this.save();
    }

    save(): void {
        var loc = this.location;
        this.gameResultService.update(this.gameResult)
            .then(errorMessage => {
                new Common(loc).showErrorOrGoBack(errorMessage);
            });
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }
}