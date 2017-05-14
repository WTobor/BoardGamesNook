import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { BoardGameService } from "./BoardGame.service";
import { BoardGame } from "./BoardGame";

@Component({
    selector: "boardGame-list",
    templateUrl: "./src/BoardGames/BoardGame-list.component.html",
})
export class BoardGameListComponent implements OnInit {
    boardGames: BoardGame[];
    selectedBoardGame: BoardGame;

    constructor(
        private boardGameService: BoardGameService,
        private router: Router) { }

    ngOnInit(): void {
        this.getBoardGames();
    }

    onSelect(boardGame: BoardGame): void {
        this.selectedBoardGame = boardGame;
    }

    getBoardGames(): void {
        this.boardGameService
            .getBoardGames()
            .then(boardGames => this.boardGames = boardGames);
    }

    delete(boardGame: BoardGame): void {
        this.boardGameService
            .delete(boardGame.Id)
            .then(() => {
                this.boardGames = this.boardGames.filter(g => g !== boardGame);
                if (this.selectedBoardGame === boardGame) { this.selectedBoardGame = null; }
            });
    }

    gotoDetail(): void {
        this.router.navigate(["/boardGames", this.selectedBoardGame.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/boardGame", 0]);
    }
}