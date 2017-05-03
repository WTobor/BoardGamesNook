﻿import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { GamerBoardGameService } from './gamerBoardGame.service';
import { GamerBoardGame } from './gamerBoardGame';

import { Common } from './../Common';

@Component({
    selector: 'gamerBoardGames-add',
    templateUrl: './src/gamers/gamerBoardGames-add.component.html'
})
export class GamerBoardGameAddComponent implements OnInit {
    gamerBoardGame: GamerBoardGame;
    
    constructor(
        private gamerBoardGameService: GamerBoardGameService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gamerBoardGameService.getGamerBoardGame(0))
            .subscribe((gamerBoardGame: GamerBoardGame) => this.gamerBoardGame = gamerBoardGame);
    }

    add(gamerId: number, gamerNick: string, boardGameId: number, boardGameName: string): void {
        this.gamerBoardGame.GamerId = gamerId;
        this.gamerBoardGame.GamerNick = gamerNick;
        this.gamerBoardGame.BoardGameId = boardGameId;
        this.gamerBoardGame.BoardGameName = boardGameName;

        var loc = this.location;
        this.gamerBoardGameService.create(this.gamerBoardGame)
            .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}