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
var app_service_gamer_1 = require('../../services/app.service.gamer');
var GamerComponent = (function () {
    function GamerComponent(_appService) {
        this._appService = _appService;
        this.gamerActive = true;
    }
    Object.defineProperty(GamerComponent.prototype, "gamer", {
        get: function () {
            return this._appService.Gamer;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(GamerComponent.prototype, "gamerList", {
        get: function () {
            return this._appService.GamerList;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(GamerComponent.prototype, "hasError", {
        get: function () {
            return this._appService.haserror;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(GamerComponent.prototype, "errorMsg", {
        get: function () {
            return this._appService.errormsg;
        },
        enumerable: true,
        configurable: true
    });
    GamerComponent.prototype.hideError = function () {
        this._appService.errormsg = null;
    };
    GamerComponent.prototype.deactivateGamer = function (gamer) {
        gamer.Active = false;
        this._appService.editGamer(gamer);
    };
    GamerComponent.prototype.addGamer = function (item) {
        if (item.valid) {
            this._appService.addGamer({
                Nick: this.gamerNick,
                Name: this.gamerName,
                Surname: this.gamerSurname,
                Age: this.gamerAge,
                City: this.gamerCity,
                Street: this.gamerStreet,
                Active: true
            });
            this.gamerNick = "";
            this.gamerName = "";
            this.gamerSurname = "";
            this.gamerAge = 0;
            this.gamerCity = "";
            this.gamerStreet = "";
        }
    };
    GamerComponent.prototype.deleteGamer = function (gamer) {
        //if (confirm("Are you sure to delete selected gamer ?")) {
        this._appService.deleteGamer(gamer);
        //}
    };
    GamerComponent = __decorate([
        core_1.Component({
            selector: 'gamer',
            templateUrl: './app/components/gamer/gamer.component.html',
            styleUrls: ['./app/components/gamer/gamer.component.css']
        }), 
        __metadata('design:paramtypes', [app_service_gamer_1.AppServiceGamer])
    ], GamerComponent);
    return GamerComponent;
}());
exports.GamerComponent = GamerComponent;
//# sourceMappingURL=gamer.component.js.map