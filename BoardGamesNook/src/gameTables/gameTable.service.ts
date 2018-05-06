﻿import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";

import { GameTable } from "./gameTable";
import { TableBoardGame } from "./tableBoardGame";
import { Observable } from "rxjs/Observable";
import { Subscriber } from "rxjs/Subscriber";
import {httpOptions} from "../common";
import {EditTableBoardGame} from "./editTableBoardGame";

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

    constructor(private http: HttpClient) {}

    getAvailableTableBoardGameList(tableId): Observable<TableBoardGame[]> {
        const url = `${this._getAvailableTableBoardGameListUrl}/${tableId}`;
        return this.http.get<TableBoardGame[]>(url);
    }

    getGameTablesByGamerNickname(gamerNickname: string): Observable<GameTable[]> {
        if (gamerNickname !== null && gamerNickname !== "") {
            const urlWithNickname = `${this._getGameTableListByGamerNicknameUrl}`;
            return this.http.get<GameTable[]>(urlWithNickname,
                {
                    params: new HttpParams().set("nickname", gamerNickname)
                });
        } else {
            const url = `${this._getGameTableListUrl}`;
            return this.http.get<GameTable[]>(url);
        }
    }

    getGameTablesWithoutResultsByGamerNickname(gamerNickname: string): Observable<GameTable[]> {
        return this.http
            .post<GameTable[]>(`${this._getGameTableListWithoutResultsUrl}`,
                JSON.stringify({ nickname: gamerNickname }),
                httpOptions);
    }

    getGameTable(id: number): Observable<GameTable> {
        if (id > 0) {
            const url = `${this._getGameTableUrl}/${id}`;
            return this.http.get<GameTable>(url);
        } else {
            return new Observable<GameTable>((subscriber: Subscriber<GameTable>) => subscriber.next(new GameTable()));
        }
    }

    deactivate(id: number): Observable<string> {
        // id - boardGameId
        const url = `${this._deactivateGameTableUrl}/${id}`;
        return this.http.post<string>(url, httpOptions);
    }

    create(gameTable: GameTable): Observable<string> {
        const url = `${this._addGameTableUrl}`;
        return this.http
            .post<string>(url, JSON.stringify(gameTable), httpOptions);
    }

    update(gameTable: GameTable): Observable<string> {
        const url = `${this._editGameTableUrl}`;

        const body = new EditTableBoardGame(
            gameTable.Id,
            gameTable.TableBoardGameList.map(x => x.BoardGameId)
        );

        return this.http
            .post<string>(url, body, httpOptions);
    }
}