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
class Gamer {
    constructor(id, name) {
        this.id = id;
        this.name = name;
    }
}
exports.Gamer = Gamer;
let HEROES = [
    new Gamer(11, 'Mr. Nice'),
    new Gamer(12, 'Narco'),
    new Gamer(13, 'Bombasto'),
    new Gamer(14, 'Celeritas'),
    new Gamer(15, 'Magneta'),
    new Gamer(16, 'RubberMan')
];
let gamersPromise = Promise.resolve(HEROES);
let GamerService = class GamerService {
    getGamers() { return gamersPromise; }
    getGamer(id) {
        return gamersPromise
            .then(gamers => gamers.find(gamer => gamer.id === +id));
    }
};
GamerService = __decorate([
    core_1.Injectable(), 
    __metadata('design:paramtypes', [])
], GamerService);
exports.GamerService = GamerService;
//# sourceMappingURL=gamer.service.js.map