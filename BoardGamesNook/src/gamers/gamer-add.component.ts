import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { Location } from "@angular/common";

import { GamerService } from "./gamer.service";
import { Gamer } from "./gamer";

import { Common } from "./../Common";

@Component({
    selector: "gamer-add",
    templateUrl: "./src/gamers/gamer-add.component.html"
})
export class GamerAddComponent implements OnInit {
    gamer: Gamer;

    constructor(
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location,
        private router: Router
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gamerService.getGamer(0))
            .subscribe((gamer: Gamer) => this.gamer = gamer);
    }

    add(nick: string, name: string, surname: string, email: string, age: number, city: string, street: string): void {
        this.gamer.Nick = nick;
        this.gamer.Name = name;
        this.gamer.Surname = surname;
        this.gamer.Email = email;
        this.gamer.Age = age;
        this.gamer.City = city;
        this.gamer.Street = street;

        var loc = this.location;
        this.gamerService.create(this.gamer)
            .then(errorMessage => {
                new Common(null, this.router).showErrorOrReturn(errorMessage);
                this.router.navigate(['']);
                window.location.reload();
            });
    }
}