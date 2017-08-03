import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { Gamer } from "./gamer";

import { Common } from "./../Common";

@Injectable()
export class GamerService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getCurrentGamerNickUrl = "gamer/GetCurrentGamerNick";
    private _getByEmailUrl = "gamer/GetByEmail";
    private _getByNickUrl = "gamer/GetByNick";
    private _getGamerListUrl = "gamer/GetAll";
    private _addGamerUrl = "gamer/Add";
    private _editGamerUrl = "gamer/Edit";
    private _deactivateGamerUrl = "gamer/Deactivate";

    constructor(private http: Http) { }

    getGamers(): Promise<Gamer[]> {
        const url = `${this._getGamerListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                console.log(response.json());
                var result = response.json() as Gamer[];
                return result;
            })
            .catch(ex => { return new Common().handleError(ex); });
    }

    getCurrentGamerNick(): Promise<string> {
        const url = `${this._getCurrentGamerNickUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    getByEmail(email: string): Promise<Gamer> {
        if (email !== "") {
            return this.http
                .post(`${this._getByEmailUrl}`, JSON.stringify({ email: email }), { headers: this.headers })
                .toPromise()
                .then(response => {
                    if (response.text() === "") {
                        return null;
                    }
                    return response.json() as Gamer;
                })
                .catch(ex => {
                    return new Common().handleError(ex);
                });
        }
        else {
            var response = new Gamer;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; });
        }
    }

    getByNick(nick: string): Promise<Gamer> {
        if (nick !== "") {
            return this.http
                .post(`${this._getByNickUrl}`, JSON.stringify({ nick: nick }), { headers: this.headers })
                .toPromise()
                .then(response => {
                    if (response.text() === "") {
                        return null;
                    }
                    return response.json() as Gamer;
                })
                .catch(ex => {
                    return new Common().handleError(ex);
                });
        }
        else {
            var response = new Gamer;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; });
        }
    }

    deactivate(id: string): Promise<string> {
        const url = `${this._deactivateGamerUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    create(gamer: Gamer): Promise<string> {
        const url = `${this._addGamerUrl}`;
        return this.http
            .post(url, JSON.stringify(gamer), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    update(gamer: Gamer): Promise<string> {
        const url = `${this._editGamerUrl}`;
        return this.http
            .post(url, JSON.stringify(gamer), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }
}