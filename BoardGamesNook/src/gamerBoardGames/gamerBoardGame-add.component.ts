﻿import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { GamerBoardGameService } from './gamerBoardGame.service';
import { GamerBoardGame } from './gamerBoardGame';

import { Common } from './../Common';

declare var jQuery: any;

@Component({
    selector: 'gamerBoardGame-add',
    templateUrl: './src/gamerBoardGames/gamerBoardGame-add.component.html'
})
export class GamerBoardGameAddComponent implements OnInit {
    gamerBoardGame: GamerBoardGame;
    gamerBoardGames: GamerBoardGame[];
    
    constructor(
        private gamerBoardGameService: GamerBoardGameService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gamerBoardGameService.getGamerAvailableBoardGames(+params['gamerId']))
            .subscribe((gamerBoardGames: GamerBoardGame[]) => this.gamerBoardGames = gamerBoardGames);

        jQuery('.selectpicker').selectpicker();
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