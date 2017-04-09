import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { BoardGameService } from './BoardGame.service';
import { BoardGame } from './BoardGame';

@Component({
    selector: 'BoardGame-add',
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

    add(name: string) : void {
        this.boardGameService.create(name)
            .then(() => this.goBack());
    }

    goBack(): void {
        this.location.back();
    }
}