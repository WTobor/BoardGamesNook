"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
require('rxjs/add/operator/switchMap');
const core_1 = require('@angular/core');
const router_1 = require('@angular/router');
const gamer_service_1 = require('./gamer.service');
let GamerListComponent = class GamerListComponent {
    constructor(service, route, router) {
        this.service = service;
        this.route = route;
        this.router = router;
    }
    ngOnInit() {
        this.gamers = this.route.params
            .switchMap((params) => {
            this.selectedId = +params['id'];
            return this.service.getGamers();
        });
    }
    isSelected(gamer) { return gamer.id === this.selectedId; }
    onSelect(gamer) {
        this.router.navigate(['/gamer', gamer.id]);
    }
};
GamerListComponent = __decorate([
    core_1.Component({
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
    }), 
    __metadata('design:paramtypes', [gamer_service_1.GamerService, router_1.ActivatedRoute, router_1.Router])
], GamerListComponent);
exports.GamerListComponent = GamerListComponent;
/*
Copyright 2017 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=gamer-list.component.js.map