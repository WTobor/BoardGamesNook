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
//import { ComposeMessageComponent } from './compose-message.component';
const not_found_component_1 = require('./not-found.component');
//import { CanDeactivateGuard } from './can-deactivate-guard.service';
const auth_guard_service_1 = require('./auth-guard.service');
//import { SelectivePreloadingStrategy } from './selective-preloading-strategy';
const appRoutes = [
    //{
    //    path: 'compose',
    //    component: ComposeMessageComponent,
    //    outlet: 'popup'
    //},
    {
        path: 'admin',
        loadChildren: 'app/admin/admin.module#AdminModule',
        canLoad: [auth_guard_service_1.AuthGuard]
    },
    //{
    //    path: 'crisis-center',
    //    loadChildren: 'app/crisis-center/crisis-center.module#CrisisCenterModule',
    //    data: { preload: true }
    //},
    { path: '', redirectTo: '/gamers', pathMatch: 'full' },
    { path: '**', component: not_found_component_1.PageNotFoundComponent }
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = __decorate([
    core_1.NgModule({
        imports: [
            router_1.RouterModule.forRoot(appRoutes)
        ],
        exports: [
            router_1.RouterModule
        ]
    }), 
    __metadata('design:paramtypes', [])
], AppRoutingModule);
exports.AppRoutingModule = AppRoutingModule;
//# sourceMappingURL=app-routing.module.js.map