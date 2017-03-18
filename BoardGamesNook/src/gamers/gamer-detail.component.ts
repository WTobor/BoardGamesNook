import 'rxjs/add/operator/switchMap';
import { Component, OnInit, HostBinding } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';

//import { slideInDownAnimation } from '../animations';

import { Gamer, GamerService } from './gamer.service';

@Component({
    selector: 'gamer-detail',
    template: `
  <h2>Gamers</h2>
  <div *ngIf="gamer">
    <h3>"{{ gamer.name }}"</h3>
    <div>
      <label>Id: </label>{{ gamer.id }}</div>
    <div>
      <label>Name: </label>
      <input [(ngModel)]="gamer.name" placeholder="name"/>
    </div>
    <p>
      <button (click)="gotoGamers()">Back</button>
    </p>
  </div>
  `
})
export class GamerDetailComponent implements OnInit {
    //@HostBinding('@routeAnimation') routeAnimation = true;
    @HostBinding('style.display') display = 'block';
    @HostBinding('style.position') position = 'absolute';

    gamer: Gamer;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private service: GamerService
    ) { }

    ngOnInit() {
        this.route.params
            // (+) converts string 'id' to a number
            .switchMap((params: Params) => this.service.getGamer(+params['id']))
            .subscribe((gamer: Gamer) => this.gamer = gamer);
    }

    gotoGamers() {
        let gamerId = this.gamer ? this.gamer.id : null;
        this.router.navigate(['/gamers', { id: gamerId, foo: 'foo' }]);
    }
}