import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";

import { BoardGameService } from "./BoardGame.service";
import { BoardGame } from "./BoardGame";

import { Common } from "./../Common";

@Component({
    selector: "boardGame-detail",
    templateUrl: "./src/BoardGames/BoardGame-detail.component.html"
})
export class BoardGameDetailComponent implements OnInit {
    boardGame: BoardGame;

    constructor(
        private boardGameService: BoardGameService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.boardGameService.getBoardGame(Number(params["id"])))
            .subscribe((boardGame: BoardGame) => this.boardGame = boardGame);
    }

    save(): void {
        var loc = this.location;
        this.boardGameService.update(this.boardGame)
            .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}