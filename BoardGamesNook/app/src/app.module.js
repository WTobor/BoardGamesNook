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
const platform_browser_1 = require('@angular/platform-browser');
const forms_1 = require('@angular/forms');
const router_1 = require('@angular/router');
const app_component_1 = require('./app.component');
const app_routing_module_1 = require('./app-routing.module');
const gamers_module_1 = require('./gamers/gamers.module');
//import { ComposeMessageComponent } from './compose-message.component';
const login_routing_module_1 = require('./login-routing.module');
const login_component_1 = require('./login.component');
const not_found_component_1 = require('./not-found.component');
const dialog_service_1 = require('./dialog.service');
let AppModule = class AppModule {
    constructor(router) {
        console.log('Routes: ', JSON.stringify(router.config, undefined, 2));
    }
};
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            gamers_module_1.GamersModule,
            login_routing_module_1.LoginRoutingModule,
            app_routing_module_1.AppRoutingModule
        ],
        declarations: [
            app_component_1.AppComponent,
            //ComposeMessageComponent,
            login_component_1.LoginComponent,
            not_found_component_1.PageNotFoundComponent
        ],
        providers: [
            dialog_service_1.DialogService
        ],
        bootstrap: [app_component_1.AppComponent]
    }), 
    __metadata('design:paramtypes', [router_1.Router])
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map