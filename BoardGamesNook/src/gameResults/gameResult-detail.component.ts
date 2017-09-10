import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";

import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";

import { Common } from "./../Common";

@Component({
    selector: "gameResult-detail",
    templateUrl: "./src/gameResults/gameResult-detail.component.html"
})
export class GameResultDetailComponent implements OnInit {
    gameResult: GameResult;
    isCurrentResult: boolean = false;

    constructor(
        private gameResultService: GameResultService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gameResultService.getByNick(params["nick"]))
            .subscribe((gameResult: GameResult) => {
                this.gameResult = gameResult;
                this.gameResultService.getCurrentGameResultNick().then(nick => {
                    if (nick === this.gameResult.GamerNick) {
                        this.isCurrentResult = true;
                    }
                });
            });
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