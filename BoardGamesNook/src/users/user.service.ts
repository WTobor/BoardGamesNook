import { Injectable } from "@angular/core";
import { Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { Common } from "./../Common";
import { User } from "./user";

@Injectable()
export class UserService {
    private _getUserUrl = "User/GetUser";

    constructor(private http: Http) { }

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
}