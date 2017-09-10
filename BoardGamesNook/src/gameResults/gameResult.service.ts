import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { GameResult } from "./gameResult";

import { Common } from "./../Common";

@Injectable()
export class GameResultService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getCurrentGameResultNickUrl = "Result/GetCurrentResultNick";
    private _getByEmailUrl = "GameResult/GetByEmail";
    private _getByNickUrl = "GameResult/GetByNick";
    private _getGameResultListUrl = "GameResult/GetAll";
    private _addGameResultUrl = "GameResult/Add";
    private _editGameResultUrl = "GameResult/Edit";
    private _deactivateGameResultUrl = "GameResult/Deactivate";

    constructor(private http: Http) { }

    getGameResults(): Promise<GameResult[]> {
        const url = `${this._getGameResultListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                var result = response.json() as GameResult[];
                return result;
            })
            .catch(ex => { return new Common().handleError(ex); });
    }

    getCurrentGameResultNick(): Promise<string> {
        const url = `${this._getCurrentGameResultNickUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    getByEmail(email: string): Promise<GameResult> {
        if (email !== "") {
            return this.http
                .post(`${this._getByEmailUrl}`, JSON.stringify({ email: email }), { headers: this.headers })
                .toPromise()
                .then(response => {
                    if (response.text() === "") {
                        return null;
                    }
                    return response.json() as GameResult;
                })
                .catch(ex => {
                    return new Common().handleError(ex);
                });
        }
        else {
            var response = new GameResult;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; });
        }
    }

    getByNick(nick: string): Promise<GameResult> {
        if (nick !== "") {
            return this.http
                .post(`${this._getByNickUrl}`, JSON.stringify({ nick: nick }), { headers: this.headers })
                .toPromise()
                .then(response => {
                    if (response.text() === "") {
                        return null;
                    }
                    return response.json() as GameResult;
                })
                .catch(ex => {
                    return new Common().handleError(ex);
                });
        }
        else {
            var response = new GameResult;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; });
        }
    }

    deactivate(id: string): Promise<string> {
        const url = `${this._deactivateGameResultUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    create(gameResult: GameResult): Promise<string> {
        const url = `${this._addGameResultUrl}`;
        return this.http
            .post(url, JSON.stringify(gameResult), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    update(gameResult: GameResult): Promise<string> {
        const url = `${this._editGameResultUrl}`;
        return this.http
            .post(url, JSON.stringify(gameResult), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }
}