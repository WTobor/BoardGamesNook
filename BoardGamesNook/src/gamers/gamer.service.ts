import { Injectable } from '@angular/core';

export class Gamer {
    constructor(public id: number, public name: string) { }
}

let HEROES = [
    new Gamer(11, 'Mr. Nice'),
    new Gamer(12, 'Narco'),
    new Gamer(13, 'Bombasto'),
    new Gamer(14, 'Celeritas'),
    new Gamer(15, 'Magneta'),
    new Gamer(16, 'RubberMan')
];

let gamersPromise = Promise.resolve(HEROES);

@Injectable()
export class GamerService {
    getGamers() { return gamersPromise; }

    getGamer(id: number | string) {
        return gamersPromise
            .then(gamers => gamers.find(gamer => gamer.id === +id));
    }
}