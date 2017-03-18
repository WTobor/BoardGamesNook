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
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var hero_service_1 = require('./hero.service');
var GamerListComponent = (function () {
    function GamerListComponent(service, route, router) {
        this.service = service;
        this.route = route;
        this.router = router;
    }
    GamerListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.gamers = this.route.params
            .switchMap(function (params) {
            _this.selectedId = +params['id'];
            return _this.service.getGamers();
        });
    };
    GamerListComponent.prototype.isSelected = function (gamer) { return gamer.id === this.selectedId; };
    GamerListComponent.prototype.onSelect = function (gamer) {
        this.router.navigate(['/gamer', gamer.id]);
    };
    GamerListComponent = __decorate([
        core_1.Component({
            template: "\n    <h2>GAMERS</h2>\n    <ul class=\"items\">\n      <li *ngFor=\"let gamer of gamers | async\"\n        [class.selected]=\"isSelected(gamer)\"\n        (click)=\"onSelect(gamer)\">\n        <span class=\"badge\">{{ gamer.id }}</span> {{ gamer.name }}\n      </li>\n    </ul>\n\n    <button routerLink=\"/sidekicks\">Go to sidekicks</button>\n  "
        }), 
        __metadata('design:paramtypes', [(typeof (_a = typeof hero_service_1.GamerService !== 'undefined' && hero_service_1.GamerService) === 'function' && _a) || Object, router_1.ActivatedRoute, router_1.Router])
    ], GamerListComponent);
    return GamerListComponent;
    var _a;
}());
exports.GamerListComponent = GamerListComponent;
/*
Copyright 2017 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=gamer-list.component.js.map