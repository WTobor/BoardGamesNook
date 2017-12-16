import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Location } from "@angular/common";

import { BoardGameService } from "./BoardGame.service";
import { BoardGame } from "./BoardGame";
import { SimilarBoardGame } from "./SimilarBoardGame";

import { Common } from "./../Common";

@Component({
    selector: "boardGame-add",
    templateUrl: "./src/BoardGames/BoardGame-add.component.html"
})
export class BoardGameAddComponent implements OnInit {
    boardGame: BoardGame;
    boardGameNotFound = false;
    similarBoardGames: SimilarBoardGame[];

    constructor(
        private boardGameService: BoardGameService,
        private route: ActivatedRoute,
        private location: Location
    ) {
    }

    ngOnInit() {
        this.route.params
            .switchMap(() => this.boardGameService.getBoardGame(0))
            .subscribe((boardGame: BoardGame) => this.boardGame = boardGame);
    }

    add(name: string): void {
        var loc = this.location;
        this.boardGameService.create(name)
            .then(result => {
                try {
                    this.similarBoardGames = JSON.parse(result);
                    this.boardGameNotFound = true;
                } catch (e) {
                    new Common(loc).showErrorOrGoBack(result);
                }
            });
    }

    onSelect(similarBoardGame: SimilarBoardGame): void {
        var loc = this.location;
        this.boardGameService.addSimilar(similarBoardGame.Id)
            .then(result => {
                new Common(loc).showErrorOrGoBack(result);
            });
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }
}