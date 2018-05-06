import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { GameResult } from "./gameResult";

import { httpOptions } from "./../Common";
import { Observable } from "rxjs/Observable";
import { Subscriber } from "rxjs/Subscriber";

@Injectable()
export class GameResultService {
    private _getGameResultUrl = "GameResult/Get";
    private _getGameResultListByTableUrl = "GameResult/GetAllByTableId";
    private _getGameResultListByGamerNicknameUrl = "GameResult/GetAllByGamerNickname";
    private _getGameResultListUrl = "GameResult/GetAll";
    private _addGameResultUrl = "GameResult/Add";
    private _addGameResultListUrl = "GameResult/AddMany";
    private _editGameResultUrl = "GameResult/Edit";
    private _deactivateGameResultUrl = "GameResult/Deactivate";

    constructor(private http: HttpClient) { }

    getList(nickname: string): Observable<GameResult[]> {
        if (nickname !== null && nickname !== undefined && nickname !== "") {
            return this.getByNickname(nickname);
        } 
        else {
            return this.getGameResults();
        }
    }

    getGameResults(): Observable<GameResult[]> {
        const url = `${this._getGameResultListUrl}`;
        return this.http.get<GameResult[]>(url);
    }

    getGameResult(id: number): Observable<GameResult> {
        if (id !== 0) {
            const url = `${this._getGameResultUrl}/${id}`;
            return this.http.get<GameResult>(url);
        }
        else {
            return new Observable<GameResult>(
                (subscriber: Subscriber<GameResult>) => subscriber.next(new GameResult()));
        }
    }

    getByTable(tableId: number): Observable<GameResult[]> {
        return this.http
            .post<GameResult[]>(`${this._getGameResultListByTableUrl}`, JSON.stringify({ tableId: tableId }), httpOptions);
    }

    getByNickname(nickname: string): Observable<GameResult[]> {
        return this.http
            .post<GameResult[]>(`${this._getGameResultListByGamerNicknameUrl}`, JSON.stringify({ nickname: nickname }), httpOptions);
    }

    create(gameResult: GameResult): Observable<string> {
        const url = `${this._addGameResultUrl}`;
        return this.http
            .post<string>(url, JSON.stringify(gameResult), httpOptions);
    }

    createMany(gameResults: GameResult[]): Observable<string> {
        const url = `${this._addGameResultListUrl}`;
        return this.http
            .post<string>(url, JSON.stringify(gameResults), httpOptions);
    }

    update(gameResult: GameResult): Observable<string> {
        const url = `${this._editGameResultUrl}`;
        return this.http
            .post<string>(url, JSON.stringify(gameResult), httpOptions);
    }

    deactivate(id: string): Observable<string> {
        const url = `${this._deactivateGameResultUrl}/${id}`;
        return this.http.post<string>(url, httpOptions);
    }
}