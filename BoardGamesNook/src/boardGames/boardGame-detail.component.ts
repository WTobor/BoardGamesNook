import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { BoardGameService } from './BoardGame.service';
import { BoardGame } from './BoardGame';

@Component({
    selector: 'BoardGame-detail',
    templateUrl: './src/BoardGames/BoardGame-detail.component.html'
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
            // (+) converts string 'id' to a number
            .switchMap((params: Params) => this.boardGameService.getBoardGame(+params['id']))
            .subscribe((boardGame: BoardGame) => this.boardGame = boardGame);
    }

    save(): void {
        this.boardGameService.update(this.boardGame)
            .then(() => this.goBack());
    }

    goBack(): void {
        this.location.back();
    }
}