import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";

import { GamerService } from "./gamer.service";
import { Gamer } from "./gamer";

import { Common } from "./../Common";

@Component({
    selector: "gamer-detail",
    templateUrl: "./src/gamers/gamer-detail.component.html"
})
export class GamerDetailComponent implements OnInit {
    gamer: Gamer;

    constructor(
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gamerService.getGamer(params["id"]))
            .subscribe((gamer: Gamer) => this.gamer = gamer);
    }

    save(): void {
        var loc = this.location;
        this.gamerService.update(this.gamer)
            .then(errorMessage => {
                if (this.gamer.IsCurrentGamer) {
                    new Common().showErrorOrReturn(errorMessage);
                }
                else {
                    new Common(loc).showErrorOrGoBack(errorMessage);
                }
            });
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}