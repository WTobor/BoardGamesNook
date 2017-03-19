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
//import 'rxjs/add/operator/switchMap';
//import { Observable } from 'rxjs/Observable';
//import { Component, OnInit } from '@angular/core';
//import { Router, ActivatedRoute, Params } from '@angular/router';
const core_1 = require('@angular/core');
const router_1 = require('@angular/router');
const gamer_service_1 = require('./gamer.service');
let GamerListComponent = class GamerListComponent {
    constructor(gamerService, router) {
        this.gamerService = gamerService;
        this.router = router;
    }
    getGamers() {
        this.gamerService
            .getGamers()
            .then(gamers => this.gamers = gamers);
    }
    ngOnInit() {
        this.getGamers();
    }
    onSelect(gamer) {
        this.selectedGamer = gamer;
    }
    gotoDetail() {
        this.router.navigate(['/gamers', this.selectedGamer.Id]);
    }
};
GamerListComponent = __decorate([
    core_1.Component({
        selector: 'gamer-list',
        templateUrl: './src/gamers/gamer-list.component.html'
    }), 
    __metadata('design:paramtypes', [gamer_service_1.GamerService, router_1.Router])
], GamerListComponent);
exports.GamerListComponent = GamerListComponent;
//# sourceMappingURL=gamer-list.component.js.map