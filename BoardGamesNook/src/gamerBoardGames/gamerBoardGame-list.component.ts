import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { GamerBoardGameService } from './gamerBoardGame.service';
import { GamerBoardGame } from './gamerBoardGame';

@Component({
    selector: 'gamerBoardGame-list',
    templateUrl: './src/gamers/gamerBoardGame-list.component.html',
})
export class GamerBoardGameListComponent implements OnInit {
    gamerBoardGames: GamerBoardGame[];
    selectedGamerBoardGame: GamerBoardGame;

    constructor(
        private gamerBoardGameService: GamerBoardGameService,
        private router: Router) { }

    ngOnInit(): void {
        this.getGamerBoardGames();
    }

    onSelect(gamerBoardGame: GamerBoardGame): void {
        this.selectedGamerBoardGame = gamerBoardGame;
    }

    getGamerBoardGames(): void {
        this.gamerBoardGameService
            .getGamerBoardGames()
            .then(gamerBoardGames => this.gamerBoardGames = gamerBoardGames);
    }

    delete(gamerBoardGame: GamerBoardGame): void {
        this.gamerBoardGameService
            .delete(gamerBoardGame.BoardGameId)
            .then(() => {
                this.gamerBoardGames = this.gamerBoardGames.filter(g => g !== gamerBoardGame);
                if (this.selectedGamerBoardGame === gamerBoardGame) { this.selectedGamerBoardGame = null; }
            });
    }

    gotoDetail(): void {
        this.router.navigate(['/gamerBoardGames', this.selectedGamerBoardGame.BoardGameId]);
    }

    gotoAdd(): void {
        this.router.navigate(['/gamerBoardGame', 0]);
    }
}