import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Common } from "../common";
import { AccountService } from "./account.service";

@Component({
    selector: "login",
    templateUrl: "./src/account/login.component.html"
})

export class LoginComponent implements OnInit {
    //login: string;
    //password: string;

    constructor(
        private accountService: AccountService,
        private router: Router) { }

    ngOnInit() {
        debugger
    }

    loginAction(login: string, password: string): void {
        debugger;
        this.accountService.loginAction(login, password)
            .then(result => new Common().showErrorOrGoBack(result));
    }
}