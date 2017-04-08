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
    BoardGame: BoardGame;

    constructor(
        private BoardGameService: BoardGameService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.BoardGameService.getBoardGame(0))
            .subscribe((BoardGame: BoardGame) => this.BoardGame = BoardGame);
    }

    add(name: string) : void {
        this.BoardGameService.create(name)
            .then(() => this.goBack());
    }

    goBack(): void {
        this.location.back();
    }
}