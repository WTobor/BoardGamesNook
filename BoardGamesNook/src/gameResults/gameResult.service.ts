import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { GameResult } from "./gameResult";

import { Common } from "./../Common";

@Injectable()
export class GameResultService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getGameResultUrl = "GameResult/Get";
    private _getByTableUrl = "GameResult/GetByTable";
    private _getByNickUrl = "GameResult/GetAllByGamerNickname";
    private _getGameResultListUrl = "GameResult/GetAll";
    private _addGameResultUrl = "GameResult/Add";
    private _addGameResultListUrl = "GameResult/AddMany";
    private _editGameResultUrl = "GameResult/Edit";

    constructor(private http: Http) { }

    getGameResults(): Promise<GameResult[]> {
        const url = `${this._getGameResultListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                var result = response.json() as GameResult[];
                return result;
            })
            .catch(err => { return Promise.reject(err); });
    }

    getGameResult(id: number): Promise<GameResult> {
        if (id !== 0) {
            const url = `${this._getGameResultUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as GameResult; })
                .catch (err => { return Promise.reject(err); });
        }
        else {
            var response = new GameResult;
            return new Promise((resolve) => { resolve(response); })
            .then(response => { return response as GameResult; })
            .catch (err => { return Promise.reject(err); });
        }
    }

    getByTable(table: number): Promise<GameResult> {
        return this.http
            .post(`${this._getByTableUrl}`, JSON.stringify({ table: table }), { headers: this.headers })
            .toPromise()
            .then(response => {
                if (response.text() === "") {
                    return null;
                }
                return response.json() as GameResult;
            })
            .catch(err => { return Promise.reject(err); });
    }

    getByNickname(nickname: string): Promise<GameResult> {
        if (nickname !== "new") {
            return this.http
                .post(`${this._getByNickUrl}`, JSON.stringify({ nickname: nickname }), { headers: this.headers })
                .toPromise()
                .then(response => {
                    if (response.text() === "") {
                        return null;
                    }
                    return response.json() as GameResult;
                })
                .catch(err => { return Promise.reject(err); });
        }
        else {
            var response = new GameResult;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response as GameResult; })
                .catch(err => { return Promise.reject(err); });
        }
    }

    create(gameResult: GameResult): Promise<string> {
        const url = `${this._addGameResultUrl}`;
        return this.http
            .post(url, JSON.stringify(gameResult), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    createMany(gameResults: GameResult[]): Promise<string> {
        const url = `${this._addGameResultListUrl}`;
        return this.http
            .post(url, JSON.stringify(gameResults), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    update(gameResult: GameResult): Promise<string> {
        const url = `${this._editGameResultUrl}`;
        return this.http
            .post(url, JSON.stringify(gameResult), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }
}