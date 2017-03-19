//import 'rxjs/add/operator/switchMap';
//import { Observable } from 'rxjs/Observable';
//import { Component, OnInit } from '@angular/core';
//import { Router, ActivatedRoute, Params } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { GamerService } from './gamer.service';
import { Gamer } from './gamer';

@Component({
    selector: 'gamer-list',
    templateUrl: './src/gamers/gamer-list.component.html'
})
export class GamerListComponent implements OnInit {
    gamers: Gamer[];
    selectedGamer: Gamer;

    constructor(
        private gamerService: GamerService,
        private router: Router) { }

    getGamers(): void {
        this.gamerService
            .getGamers()
            .then(gamers => this.gamers = gamers);
    }

    ngOnInit(): void {
        this.getGamers();
    }

    onSelect(gamer: Gamer): void {
        this.selectedGamer = gamer;
    }

    gotoDetail(): void {
        this.router.navigate(['/gamers', this.selectedGamer.Id]);
    }
}