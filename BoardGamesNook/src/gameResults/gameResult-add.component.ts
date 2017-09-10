import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Location } from "@angular/common";

import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";

import { Common } from "./../Common";

@Component({
    selector: "gameResult-add",
    templateUrl: "./src/gameResults/gameResult-add.component.html"
})
export class GameResultAddComponent implements OnInit {
    gameResult: GameResult;

    constructor(
        private gameResultService: GameResultService,
        private route: ActivatedRoute,
        private location: Location,
        private router: Router
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap(() => this.gameResultService.getByNick("new"))
            .subscribe((gameResult: GameResult) => this.gameResult = gameResult);
    }

    add(): void {
        this.gameResult = new GameResult;
        //TODO

        this.gameResultService.create(this.gameResult)
            .then(errorMessage => {
                new Common(null, this.router).showErrorOrReturn(errorMessage);
                this.router.navigate([""]);
                window.location.reload();
            });
    }
}