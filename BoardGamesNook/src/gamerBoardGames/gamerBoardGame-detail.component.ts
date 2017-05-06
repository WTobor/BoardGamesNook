import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { GamerBoardGameService } from './gamerBoardGame.service';
import { GamerBoardGame } from './gamerBoardGame';

import { Common } from './../Common';

@Component({
    selector: 'gamerBoardGame-detail',
    templateUrl: './src/gamerBoardGames/gamerBoardGame-detail.component.html'
})
export class GamerBoardGameDetailComponent implements OnInit {
    gamerBoardGame: GamerBoardGame;
    
    constructor(
        private gamerBoardGameService: GamerBoardGameService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gamerBoardGameService.getGamerBoardGame(Number(params['id'])))
            .subscribe((gamerBoardGame: GamerBoardGame) => this.gamerBoardGame = gamerBoardGame);
    }

    save(): void {
        var loc = this.location;
        this.gamerBoardGameService.update(this.gamerBoardGame)
            .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}