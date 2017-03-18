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
var core_1 = require('@angular/core');
var common_1 = require('@angular/common');
var forms_1 = require('@angular/forms');
var gamer_list_component_1 = require('./gamer-list.component');
var gamer_detail_component_1 = require('./gamer-detail.component');
var gamer_service_1 = require('./gamer.service');
var gamers_routing_module_1 = require('./gamers-routing.module');
var GamersModule = (function () {
    function GamersModule() {
    }
    GamersModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                forms_1.FormsModule,
                gamers_routing_module_1.GamerRoutingModule
            ],
            declarations: [
                gamer_list_component_1.GamerListComponent,
                gamer_detail_component_1.GamerDetailComponent
            ],
            providers: [gamer_service_1.GamerService]
        }), 
        __metadata('design:paramtypes', [])
    ], GamersModule);
    return GamersModule;
}());
exports.GamersModule = GamersModule;
//# sourceMappingURL=gamers.module.js.map