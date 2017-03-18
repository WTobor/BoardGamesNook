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
const core_1 = require('@angular/core');
const router_1 = require('@angular/router');
const gamer_list_component_1 = require('./gamer-list.component');
const gamer_detail_component_1 = require('./gamer-detail.component');
const gamersRoutes = [
    { path: 'gamers', component: gamer_list_component_1.GamerListComponent },
    { path: 'gamer/:id', component: gamer_detail_component_1.GamerDetailComponent }
];
let GamerRoutingModule = class GamerRoutingModule {
};
GamerRoutingModule = __decorate([
    core_1.NgModule({
        imports: [
            router_1.RouterModule.forChild(gamersRoutes)
        ],
        exports: [
            router_1.RouterModule
        ]
    }), 
    __metadata('design:paramtypes', [])
], GamerRoutingModule);
exports.GamerRoutingModule = GamerRoutingModule;
//# sourceMappingURL=gamers-routing.module.js.map