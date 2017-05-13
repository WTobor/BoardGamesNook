import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { GameTableService } from './gameTable.service';
import { GameTable } from './gameTable';

import { Common } from './../Common';

@Component({
    selector: 'gameTable-detail',
    templateUrl: './src/gameTables/gameTable-detail.component.html'
})
export class GameTableDetailComponent implements OnInit {
    gameTable: GameTable;
    
    constructor(
        private gameTableService: GameTableService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gameTableService.getGameTable(Number(params['id'])))
            .subscribe((gameTable: GameTable) => this.gameTable = gameTable);
    }

    save(): void {
        var loc = this.location;
        this.gameTableService.update(this.gameTable)
            .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}