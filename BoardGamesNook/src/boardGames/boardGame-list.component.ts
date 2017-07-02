import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";

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
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit(): void {
        this.route.params
            .switchMap((params: Params) => this.boardGameService.getBoardGames())
            .subscribe((boardGameList: BoardGame[]) => {
                this.boardGames = boardGameList;
            });
    }

    onSelect(boardGame: BoardGame): void {
        this.selectedBoardGame = boardGame;
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