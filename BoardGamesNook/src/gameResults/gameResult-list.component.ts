import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";

@Component({
    selector: "gameResult-list",
    templateUrl: "./src/gameResults/gameResult-list.component.html",
})
export class GameResultListComponent implements OnInit {
    gameResults: GameResult[];
    selectedGameResult: GameResult;
    isAdmin: boolean = false;

    constructor(
        private gameResultService: GameResultService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.getResults();
    }

    onSelect(gameResult: GameResult): void {
        this.selectedGameResult = gameResult;
    }

    getResults(): void {
        this.gameResultService
            .getGameResults()
            .then(results => {
                this.gameResults = results;
            });
    }

    gotoDetail(): void {
        this.router.navigate(["/gameResults", this.selectedGameResult.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/gameResult", 0]);
    }
}