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
    otherTableGameResults: GameResult[];
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
                if (this.gameResult.GameTableId !== undefined) {
                    this.gameResultService.getByTable(this.gameResult.GameTableId).then((gameResults: GameResult[]) => {
                        this.otherTableGameResults = gameResults.filter(x => x.Id !== this.gameResult.Id);
                    });
                }

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
        if (this.otherTableGameResults) {
            var duplicatedPoints = this.otherTableGameResults.find(x => x.Points === this.gameResult.Points);
            var duplicatedPlace = this.otherTableGameResults.find(x => x.Place === this.gameResult.Place);
            if (duplicatedPoints && duplicatedPlace ) {
                if (confirm("Gracz " + duplicatedPoints.GamerNickname + " ma taką samą liczbę punktów i miejsce. Czy na pewno zapisać zmiany?")) {
                    this.save();
                } 
                else {
                    return;
                }
            }
            else if (duplicatedPoints) {
                confirm("Gracz " + duplicatedPoints.GamerNickname + " ma taką samą liczbę punktów. Zmień miejsce gracza lub popraw dane.");
                return;
            }
            else if (duplicatedPlace) {
                confirm("Gracz " + duplicatedPlace.GamerNickname + " ma takie samo miejsce. Zmień liczbę punktów gracza lub popraw dane.");
                return;
            }
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