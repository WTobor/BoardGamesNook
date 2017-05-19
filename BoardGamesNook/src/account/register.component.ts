import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { Common } from "../common";
import { AccountService } from "./account.service";

@Component({
    selector: "register",
    templateUrl: "./src/account/register.component.html"
})

export class RegisterComponent implements OnInit  {
    //login: string;
    //password: string;

    constructor(
        private router: Router,
        private accountService: AccountService
    ) { }

    ngOnInit() {
        debugger
    }

    register(login: string, password: string) {
        this.accountService.registerAction(login, password)
            .then(errorMessage => { new Common().showErrorOrGoBack(errorMessage); });
    }
}