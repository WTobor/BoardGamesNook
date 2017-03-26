//import 'rxjs/add/operator/switchMap';
//import { Observable } from 'rxjs/Observable';
//import { Component, OnInit } from '@angular/core';
//import { Router, ActivatedRoute, Params } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { GamerService } from './gamer.service';
import { Gamer } from './gamer';

@Component({
    selector: 'gamer-list',
    templateUrl: './src/gamers/gamer-list.component.html'
})
export class GamerListComponent implements OnInit {
    gamers: Gamer[];
    selectedGamer: Gamer;

    constructor(
        private gamerService: GamerService,
        private router: Router) { }

    ngOnInit(): void {
        this.getGamers();
    }

    onSelect(gamer: Gamer): void {
        this.selectedGamer = gamer;
    }

    getGamers(): void {
        this.gamerService
            .getGamers()
            .then(gamers => this.gamers = gamers);
    }

    add(nick: string, name: string, surname: string, age: number, city: string, street: string): void {
        debugger
        var gamer = new Gamer();
        gamer.Id = 0;
        gamer.CreatedDate = null;
        gamer.Active = true;
        gamer.Nick = nick;
        gamer.Name = name;
        gamer.Surname = surname;
        gamer.Age = age;
        gamer.City = city;
        gamer.Street = street;
        this.gamerService.create(gamer)
            .then(gamer => {
                this.gamers.push(gamer);
                this.selectedGamer = null;
            });
    }

    delete(gamer: Gamer): void {
        this.gamerService
            .delete(gamer.Id)
            .then(() => {
                this.gamers = this.gamers.filter(g => g !== gamer);
                if (this.selectedGamer === gamer) { this.selectedGamer = null; }
            });
    }

    

    gotoDetail(): void {
        this.router.navigate(['/gamers', this.selectedGamer.Id]);
    }

}