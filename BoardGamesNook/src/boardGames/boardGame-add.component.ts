import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { BoardGameService } from './BoardGame.service';
import { BoardGame } from './BoardGame';

import { Common } from './../Common';

@Component({
    selector: 'boardGame-add',
    templateUrl: './src/BoardGames/BoardGame-add.component.html'
})
export class BoardGameAddComponent implements OnInit {
    boardGame: BoardGame;

    constructor(
        private boardGameService: BoardGameService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.boardGameService.getBoardGame(0))
            .subscribe((boardGame: BoardGame) => this.boardGame = boardGame);
    }

    add(name: string): void {
        var loc = this.location;
        this.boardGameService.create(name)
            .then(errorMessage => {
                new Common(loc).showErrorOrGoBack(errorMessage);
            });
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}