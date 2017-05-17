import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { Common } from "./../Common";
import { UserGamer } from "./userGamer";

@Injectable()
export class UserGamerService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getUserGamerUrl = "UserGamer/Get";
    private _getUserGamerListUrl = "UserGamer/GetAll";
    private _addUserGamerUrl = "UserGamer/Add";
    private _editUserGamerUrl = "UserGamer/Edit";
    private _deleteUserGamerUrl = "UserGamer/Delete";

    constructor(private http: Http) { }

    getUserGamers(): Promise<UserGamer[]> {
        const url = `${this._getUserGamerListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                console.log(response.json());
                return response.json() as UserGamer[];
            })
            .catch(ex => { return new Common().handleError(ex); });
    }

    getUserGamer(id: number): Promise<UserGamer> {
        if (id !== 0) {
            const url = `${this._getUserGamerUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as UserGamer; })
                .catch(ex => { return new Common().handleError(ex); });
        }
        else {
            var response = new UserGamer;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; });
        }
    }

    delete(id: number): Promise<string> {
        const url = `${this._deleteUserGamerUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    create(userUserGamer: UserGamer): Promise<string> {
        const url = `${this._addUserGamerUrl}`;
        return this.http
            .post(url, JSON.stringify(userUserGamer), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    update(userUserGamer: UserGamer): Promise<string> {
        const url = `${this._editUserGamerUrl}`;
        return this.http
            .post(url, JSON.stringify(userUserGamer), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }
}