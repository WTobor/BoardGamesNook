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
//import { slideInDownAnimation } from '../animations';
var gamer_service_1 = require('./gamer.service');
var GamerDetailComponent = (function () {
    function GamerDetailComponent(route, router, service) {
        this.route = route;
        this.router = router;
        this.service = service;
        this.routeAnimation = true;
        this.display = 'block';
        this.position = 'absolute';
    }
    GamerDetailComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params
            .switchMap(function (params) { return _this.service.getGamer(+params['id']); })
            .subscribe(function (gamer) { return _this.gamer = gamer; });
    };
    GamerDetailComponent.prototype.gotoGamers = function () {
        var gamerId = this.gamer ? this.gamer.id : null;
        this.router.navigate(['/gamers', { id: gamerId, foo: 'foo' }]);
    };
    __decorate([
        core_1.HostBinding('@routeAnimation'), 
        __metadata('design:type', Object)
    ], GamerDetailComponent.prototype, "routeAnimation", void 0);
    __decorate([
        core_1.HostBinding('style.display'), 
        __metadata('design:type', Object)
    ], GamerDetailComponent.prototype, "display", void 0);
    __decorate([
        core_1.HostBinding('style.position'), 
        __metadata('design:type', Object)
    ], GamerDetailComponent.prototype, "position", void 0);
    GamerDetailComponent = __decorate([
        core_1.Component({
            template: "\n  <h2>Gamers</h2>\n  <div *ngIf=\"gamer\">\n    <h3>\"{{ gamer.name }}\"</h3>\n    <div>\n      <label>Id: </label>{{ gamer.id }}</div>\n    <div>\n      <label>Name: </label>\n      <input [(ngModel)]=\"gamer.name\" placeholder=\"name\"/>\n    </div>\n    <p>\n      <button (click)=\"gotoGamers()\">Back</button>\n    </p>\n  </div>\n  "
        }), 
        __metadata('design:paramtypes', [router_1.ActivatedRoute, router_1.Router, gamer_service_1.GamerService])
    ], GamerDetailComponent);
    return GamerDetailComponent;
}());
exports.GamerDetailComponent = GamerDetailComponent;
//# sourceMappingURL=gamer-detail.component.js.map