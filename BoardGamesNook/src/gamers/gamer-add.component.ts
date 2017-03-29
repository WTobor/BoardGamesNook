import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { GamerService } from './gamer.service';
import { Gamer } from './gamer';

@Component({
    selector: 'gamer-add',
    templateUrl: './src/gamers/gamer-add.component.html'
})
export class GamerAddComponent implements OnInit {
    gamer: Gamer;
    
    constructor(
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gamerService.getGamer(0))
            .subscribe((gamer: Gamer) => this.gamer = gamer);
    }

    add(nick: string, name: string, surname: string, age: number, city: string, street: string): void {
        this.gamer.Id = 0;
        this.gamer.CreatedDate = null;
        this.gamer.Active = true;
        this.gamer.Nick = nick;
        this.gamer.Name = name;
        this.gamer.Surname = surname;
        this.gamer.Age = age;
        this.gamer.City = city;
        this.gamer.Street = street;
        this.gamerService.create(this.gamer)
            .then(() => this.goBack());
    }

    goBack(): void {
        this.location.back();
    }
}