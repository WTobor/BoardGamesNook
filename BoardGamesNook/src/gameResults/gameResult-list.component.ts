import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";

@Component({
    selector: "gameResult-list",
    templateUrl: "./src/gameResults/gameResult-list.component.html",
})
export class GameResultListComponent implements OnInit {
    gameResults: GameResult[];
    selectedGameResult: GameResult;
    isAdmin = false;

    constructor(
        private readonly gameResultService: GameResultService,
        private readonly router: Router,
        private route: ActivatedRoute
    ) {
    }

    ngOnInit(): void {
        this.gameResultService.getList(this.route.snapshot.paramMap.get("nickname"))
            .subscribe((gameResults: GameResult[]) => {
                this.gameResults = gameResults;
            });
    }

    onSelect(gameResult: GameResult): void {
        this.selectedGameResult = gameResult;
    }

    gotoDetail(): void {
        this.router.navigate(["/gameResult", this.selectedGameResult.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/gameResult", 0]);
    }

    gotoAddMany(): void {
        this.router.navigate(["/gameResults", 0]);
    }
}