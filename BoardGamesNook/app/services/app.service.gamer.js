"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
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
var http_1 = require('@angular/http');
var HttpHelpers_1 = require('../utils/HttpHelpers');
require('rxjs/Rx');
var AppServiceGamer = (function (_super) {
    __extends(AppServiceGamer, _super);
    function AppServiceGamer(http) {
        var _this = this;
        _super.call(this, http);
        this.http = http;
        this._getGamerUrl = 'Gamer/Get';
        this._getGamerListUrl = 'Gamer/GetAll';
        this._getGamerAddUrl = 'Gamer/Add';
        this._getTGamerEditUrl = 'Gamer/Edit';
        this._getGamerDeleteUrl = 'Gamer/Delete';
        this.getaction(this._getGamerUrl).subscribe(function (result) {
            _this._gamer = result;
        }, function (error) { return _this.errormsg = error; });
    }
    Object.defineProperty(AppServiceGamer.prototype, "gamer", {
        get: function () {
            return this._gamer;
        },
        enumerable: true,
        configurable: true
    });
    //get gamerList(): Models.Gamer[] {
    //    return this._gamerList;
    //}
    AppServiceGamer.prototype.addGamer = function (gamer) {
        var _this = this;
        this.postaction(gamer, this._getGamerAddUrl).subscribe(function (result) {
            if (!result.haserror) {
                _this.GamerList.push(result.element);
            }
        }, function (error) { return _this.errormsg = error; });
    };
    AppServiceGamer.prototype.editGamer = function (gamer) {
        var _this = this;
        this.postaction(gamer, this._getTGamerEditUrl).subscribe(function (result) { return result; }, function (error) { return _this.errormsg = error; });
    };
    AppServiceGamer.prototype.deleteGamer = function (gamer) {
        var _this = this;
        this.postaction(gamer, this._getGamerDeleteUrl).subscribe(function (result) {
            if (!result.haserror) {
                var index = _this.GamerList.indexOf(gamer, 0);
                if (index > -1) {
                    _this.GamerList.splice(index, 1);
                }
            }
        }, function (error) { return _this.errormsg = error; });
    };
    AppServiceGamer = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], AppServiceGamer);
    return AppServiceGamer;
}(HttpHelpers_1.HttpHelpers));
exports.AppServiceGamer = AppServiceGamer;
//# sourceMappingURL=app.service.gamer.js.map