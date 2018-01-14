import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { GameTable } from "./gameTable";

import { Common } from "./../Common";
import { TableBoardGame } from "./tableBoardGame";

@Injectable()
export class GameTableService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getGameTableUrl = "GameTable/Get";
    private _getGameTableListUrl = "GameTable/GetAll";
    private _getGameTableListByGamerNicknameUrl = "GameTable/GetAllByGamerNickname";
    private _getAvailableTableBoardGameListUrl = "GameTable/GetAvailableTableBoardGameList";
    private _addGameTableUrl = "GameTable/Add";
    private _editGameTableUrl = "GameTable/Edit";
    private _deleteGameTableUrl = "GameTable/Delete";

    constructor(private http: Http) { }

    getAvailableTableBoardGameList(tableId): Promise<TableBoardGame[]> {
        const url = `${this._getAvailableTableBoardGameListUrl}/${tableId}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                console.log(response.json());
                return response.json() as TableBoardGame[];
            })
            .catch (err => { return Promise.reject(err); });
    }

    getGameTablesByGamerNickname(gamerNickname: string): Promise<GameTable[]> {
        var url = `${this._getGameTableListUrl}`;
        if (gamerNickname != null && gamerNickname !== "") {
            url = `${this._getGameTableListByGamerNicknameUrl}/${gamerNickname}`;
        };
        
        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as GameTable[];
            })
            .catch (err => { return Promise.reject(err); });
    }

    getGameTable(id: number): Promise<GameTable> {
        if (id > 0) {
            const url = `${this._getGameTableUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as GameTable; })
                .catch (err => { return Promise.reject(err); });
        }
        else {
            var response = new GameTable;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response as GameTable; })
                .catch (err => { return Promise.reject(err); });
        }
    }

    delete(id: number): Promise<string> {
        // id - boardGameId
        const url = `${this._deleteGameTableUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch (err => { return Promise.reject(err); });
    }

    create(gameTable: GameTable): Promise<string> {
        const url = `${this._addGameTableUrl}`;
        return this.http
            .post(url, JSON.stringify(gameTable), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch (err => { return Promise.reject(err); });
    }

    update(gameTable: GameTable): Promise<string> {
        const url = `${this._editGameTableUrl}`;
        return this.http
            .post(url, JSON.stringify(gameTable), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch (err => { return Promise.reject(err); });
    }
}