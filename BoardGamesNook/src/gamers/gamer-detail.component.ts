import 'rxjs/add/operator/switchMap';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { GamerService } from './gamer.service';
import { Gamer } from './gamer';

@Component({
    selector: 'gamer-detail',
    templateUrl: './src/gamers/gamer-detail.component.html'
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
            // (+) converts string 'id' to a number
            .switchMap((params: Params) => this.gamerService.getGamer(+params['id']))
            .subscribe((gamer: Gamer) => this.gamer = gamer);
    }

    save(): void {
        this.gamerService.update(this.gamer)
            .then(() => this.goBack());
    }

    goBack(): void {
        this.location.back();
    }
}