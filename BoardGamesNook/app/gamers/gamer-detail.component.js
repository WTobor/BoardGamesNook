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
//import { slideInDownAnimation } from '../animations';
const gamer_service_1 = require('./gamer.service');
let GamerDetailComponent = class GamerDetailComponent {
    constructor(route, router, service) {
        this.route = route;
        this.router = router;
        this.service = service;
        //@HostBinding('@routeAnimation') routeAnimation = true;
        this.display = 'block';
        this.position = 'absolute';
    }
    ngOnInit() {
        this.route.params
            .switchMap((params) => this.service.getGamer(+params['id']))
            .subscribe((gamer) => this.gamer = gamer);
    }
    gotoGamers() {
        let gamerId = this.gamer ? this.gamer.id : null;
        this.router.navigate(['/gamers', { id: gamerId, foo: 'foo' }]);
    }
};
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
        selector: 'gamer-detail',
        template: `
  <h2>Gamers</h2>
  <div *ngIf="gamer">
    <h3>"{{ gamer.name }}"</h3>
    <div>
      <label>Id: </label>{{ gamer.id }}</div>
    <div>
      <label>Name: </label>
      <input [(ngModel)]="gamer.name" placeholder="name"/>
    </div>
    <p>
      <button (click)="gotoGamers()">Back</button>
    </p>
  </div>
  `
    }), 
    __metadata('design:paramtypes', [router_1.ActivatedRoute, router_1.Router, gamer_service_1.GamerService])
], GamerDetailComponent);
exports.GamerDetailComponent = GamerDetailComponent;
//# sourceMappingURL=gamer-detail.component.js.map