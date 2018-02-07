import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { GameTable } from "./gameTable";
import { TableBoardGame } from "./tableBoardGame";
import { Observable } from "rxjs/Observable";
import {httpOptions} from "../common";

@Injectable()
export class GameTableService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getGameTableUrl = "GameTable/Get";
    private _getGameTableListUrl = "GameTable/GetAll";
    private _getGameTableListByGamerNicknameUrl = "GameTable/GetAllByGamerNickname";
    private _getGameTableListWithoutResultsUrl = "GameTable/GetAllWithoutResultsByGamerNickname";
    private _getAvailableTableBoardGameListUrl = "GameTable/GetAvailableTableBoardGameList";
    private _addGameTableUrl = "GameTable/Add";
    private _editGameTableUrl = "GameTable/Edit";
    private _deactivateGameTableUrl = "GameTable/Deactivate";

    constructor(private http: HttpClient) { }

    getAvailableTableBoardGameList(tableId): Observable<TableBoardGame[]> {
        const url = `${this._getAvailableTableBoardGameListUrl}/${tableId}`;
        return this.http.get<TableBoardGame[]> (url);
    }

    getGameTablesByGamerNickname(gamerNickname: string): Observable<GameTable[]> {
        var url = `${this._getGameTableListUrl}`;
        if (gamerNickname != null && gamerNickname !== "") {
            url = `${this._getGameTableListByGamerNicknameUrl}/${gamerNickname}`;
        };

        return this.http.get<GameTable[]>(url);
    }

    getGameTablesWithoutResultsByGamerNickname(gamerNickname: string): Observable<GameTable[]> {
        var url = `${this._getGameTableListWithoutResultsUrl}`;
        if (gamerNickname != null && gamerNickname !== "") {
            url = `${this._getGameTableListByGamerNicknameUrl}/${gamerNickname}`;
        };
        
        return this.http.get<GameTable[]> (url);
    }

    getGameTable(id: number): Observable<GameTable> {
        if (id > 0) {
            const url = `${this._getGameTableUrl}/${id}`;
            return this.http.get<GameTable> (url);
        }
        else {
            var response = new GameTable;;
        }
    }

    deactivate(id: number): Observable<string> {
        // id - boardGameId
        const url = `${this._deactivateGameTableUrl}/${id}`;
        return this.http.post<string> (url, httpOptions);
    }

    create(gameTable: GameTable): Observable<string> {
        const url = `${this._addGameTableUrl}`;
        return this.http
            .post<string> (url, JSON.stringify(gameTable), httpOptions);
    }

    update(gameTable: GameTable): Observable<string> {
        const url = `${this._editGameTableUrl}`;
        return this.http
            .post<string> (url, JSON.stringify(gameTable), httpOptions);
    }
}