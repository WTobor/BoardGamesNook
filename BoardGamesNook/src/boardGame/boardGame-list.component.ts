import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { BoardGameService } from './BoardGame.service';
import { BoardGame } from './BoardGame';

@Component({
    selector: 'BoardGame-list',
    templateUrl: './src/BoardGames/BoardGame-list.component.html',
})
export class BoardGameListComponent implements OnInit {
    BoardGames: BoardGame[];
    selectedBoardGame: BoardGame;

    constructor(
        private BoardGameService: BoardGameService,
        private router: Router) { }

    ngOnInit(): void {
        this.getBoardGames();
    }

    onSelect(BoardGame: BoardGame): void {
        this.selectedBoardGame = BoardGame;
    }

    getBoardGames(): void {
        this.BoardGameService
            .getBoardGames()
            .then(BoardGames => this.BoardGames = BoardGames);
    }

    delete(BoardGame: BoardGame): void {
        this.BoardGameService
            .delete(BoardGame.Id)
            .then(() => {
                this.BoardGames = this.BoardGames.filter(g => g !== BoardGame);
                if (this.selectedBoardGame === BoardGame) { this.selectedBoardGame = null; }
            });
    }

    gotoDetail(): void {
        this.router.navigate(['/BoardGames', this.selectedBoardGame.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(['/BoardGame', 0]);
    }
}