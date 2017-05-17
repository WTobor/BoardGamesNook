import { Component } from '@angular/core';
import { Router } from '@angular/router';

import {Common} from "../common";
import {UserGamer} from "../userGamer/userGamer";
import {UserGamerService} from "../userGamer/userGamer.service";

@Component({
    selector: "register",
    templateUrl: 'register.component.html'
})

export class RegisterComponent {
    userGamer: UserGamer;
    loading = false;

    constructor(
        private router: Router,
        private userGamerService: UserGamerService
    ) { }

    register() {
        this.loading = true;
        this.userGamerService.create(this.userGamer)
            .then(errorMessage => { new Common().showErrorOrGoBack(errorMessage); });
    }
}