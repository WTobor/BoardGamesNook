import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

import { Gamer, GamerService } from './gamer.service';

@Component({
    selector: 'gamer-list',
    template: `
    <h2>GAMERS</h2>
    <ul class="items">
      <li *ngFor="let gamer of gamers | async"
        [class.selected]="isSelected(gamer)"
        (click)="onSelect(gamer)">
        <span class="badge">{{ gamer.id }}</span> {{ gamer.name }}
      </li>
    </ul>

    <button routerLink="/sidekicks">Go to sidekicks</button>
  `
})
export class GamerListComponent implements OnInit {
    gamers: Observable<Gamer[]>;

    private selectedId: number;

    constructor(
        private service: GamerService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit() {
        this.gamers = this.route.params
            .switchMap((params: Params) => {
                this.selectedId = +params['id'];
                return this.service.getGamers();
            });
    }

    isSelected(gamer: Gamer) { return gamer.id === this.selectedId; }

    onSelect(gamer: Gamer) {
        this.router.navigate(['/gamer', gamer.id]);
    }
}


/*
Copyright 2017 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/