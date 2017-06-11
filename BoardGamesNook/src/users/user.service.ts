import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Router } from "@angular/router";

import "rxjs/add/operator/toPromise";

import { Common } from "./../Common";
import { User } from "./user";

@Injectable()
export class UserService {
    private _getUserUrl = "User/GetUser";
    private _logOutUserUrl = "User/LogOutUser";

    constructor(private http: Http, private router: Router) { }

    getUser(): Promise<User> {
        const url = `${this._getUserUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                debugger
                if (response.text() === "") {
                    return null;
                }
                return response.json() as User || null;
            })
            .catch(ex => { return new Common().handleError(ex); });
    }

    logOutUser(): void {
        const url = `${this._logOutUserUrl}`;
        this.http.get(url)
            .toPromise()
            .then(() => {
                this.router.navigate(['/']);
                window.location.reload();
            })
            .catch(ex => { return new Common().handleError(ex); });
    }
}