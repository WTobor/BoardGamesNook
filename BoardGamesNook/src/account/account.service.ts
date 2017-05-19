import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { Common } from "./../Common";

@Injectable()
export class AccountService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _loginUrl = "Account/Login";
    private _registerUrl = "Account/Register";

    constructor(private http: Http) { }

    loginAction(login: string, password: string): Promise<string> {
        debugger;
        return this.http
            .post(`${this._loginUrl}`,
            JSON.stringify({ login: login, password: password }),
            { headers: this.headers })
            .toPromise()
            .then(response => {
                var success = response.json() as boolean;
                if (success) {
                    window.location.href = "...";
                    return "";
                } else {
                    return "Nie udało się zalogować";
                }
            })
            .catch(ex => { return new Common().handleError(ex); });
    }

    registerAction(login: string, password: string): Promise<string> {
        debugger
        return this.http
            .post(`${this._registerUrl}`,
            JSON.stringify({ login: login, password: password }),
            { headers: this.headers })
            .toPromise()
            .then(response => {
                var success = response.json() as boolean;
                if (success) {
                    return "Z powodzeniem utworzono nowe konto";
                } else {
                    return "Nie udało się utworzyć nowego konta";
                }
            })
            .catch(ex => { return new Common().handleError(ex); });
    }
}