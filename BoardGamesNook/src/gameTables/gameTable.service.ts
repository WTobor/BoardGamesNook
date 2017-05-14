import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { GameTable } from "./gameTable";

import { Common } from "./../Common";

@Injectable()
export class GameTableService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getGameTableUrl = "GameTable/Get";
    private _getGameTableListUrl = "GameTable/GetAll";
    private _addGameTableUrl = "GameTable/Add";
    private _editGameTableUrl = "GameTable/Edit";
    private _deleteGameTableUrl = "GameTable/Delete";

    constructor(private http: Http) { }

    getGameTables(): Promise<GameTable[]> {
        const url = `${this._getGameTableListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                console.log(response.json());
                 return response.json() as GameTable[];
            })
            .catch(ex => { return new Common().handleError(ex); });
    }

    getGameTable(id: number): Promise<GameTable> {
        if (id !== 0) {
            const url = `${this._getGameTableUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as GameTable; })
                .catch(ex => { return new Common().handleError(ex); });
        }
        else {
            var response = new GameTable;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; });
        }
    }

    delete(id: number): Promise<string> {
        // id - boardGameId
        const url = `${this._deleteGameTableUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    create(gameTable: GameTable): Promise<string> {
        const url = `${this._addGameTableUrl}`;
        return this.http
            .post(url, JSON.stringify(gameTable), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    update(gameTable: GameTable): Promise<string> {
        const url = `${this._editGameTableUrl}`;
        return this.http
            .post(url, JSON.stringify(gameTable) , { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }
}