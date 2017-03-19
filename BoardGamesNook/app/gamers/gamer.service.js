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
//import { Injectable } from '@angular/core';
//import { Http } from '@angular/http';
//import { HttpHelpers } from '../http-helpers';
const core_1 = require('@angular/core');
const http_1 = require('@angular/http');
require('rxjs/add/operator/toPromise');
let GamerService = class GamerService {
    constructor(http) {
        this.http = http;
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        this._getGamerUrl = 'Gamer/Get';
        this._getGamerListUrl = 'Gamer/GetAll';
    }
    getGamers() {
        const url = `${this._getGamerListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
            console.log(response.json());
            return response.json();
        })
            .catch(this.handleError);
    }
    getGamer(id) {
        const url = `${this._getGamerUrl}/${id}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
            console.log(response.json());
            return response.json();
        })
            .catch(this.handleError);
    }
    handleError(error) {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
};
GamerService = __decorate([
    core_1.Injectable(), 
    __metadata('design:paramtypes', [http_1.Http])
], GamerService);
exports.GamerService = GamerService;
//# sourceMappingURL=gamer.service.js.map