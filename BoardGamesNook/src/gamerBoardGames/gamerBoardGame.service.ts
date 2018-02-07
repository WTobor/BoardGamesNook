import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { GamerBoardGame } from "./gamerBoardGame";
import { Observable } from "rxjs/Observable";
import {httpOptions} from "../common";

@Injectable()
export class GamerBoardGameService {
    private _getGamerBoardGameUrl = "GamerBoardGame/Get";
    private _getGamerBoardGameListUrl = "GamerBoardGame/GetAllByGamerNickname";
    private _addGamerBoardGameUrl = "GamerBoardGame/Add";
    private _editGamerBoardGameUrl = "GamerBoardGame/Edit";
    private _deactivateGamerBoardGameUrl = "GamerBoardGame/Deactivate";
    private _getGamerAvailableBoardGamesUrl = "GamerBoardGame/GetGamerAvailableBoardGames";

    constructor(private http: HttpClient) { }

    getGamerBoardGames(gamerNickname: string): Observable<GamerBoardGame[]> {
        const url = `${this._getGamerBoardGameListUrl}/${gamerNickname}`;
        return this.http.get<GamerBoardGame[]>(url);
    }

    getGamerBoardGame(id: number): Observable<GamerBoardGame> {
        if (id > 0) {
            const url = `${this._getGamerBoardGameUrl}/${id}`;
            return this.http.get<GamerBoardGame>(url);
        }
        else {
            return new Observable<GamerBoardGame>();
        }
    }

    getGamerAvailableBoardGames(gamerNickname: string): Observable<GamerBoardGame[]> {
        const url = `${this._getGamerAvailableBoardGamesUrl}/${gamerNickname}`;
        return this.http.post<GamerBoardGame[]>(url, httpOptions);
    }

    deactivate(id: number): Observable<string> {
        const url = `${this._deactivateGamerBoardGameUrl}/${id}`;
        return this.http.post<string>(url, httpOptions);
    }

    create(boardGameId: number): Observable<string> {
        const url = `${this._addGamerBoardGameUrl}`;
        var body = JSON.stringify({ boardGameId: boardGameId });
        this.http.post<string>(url, body, httpOptions);

        return this.http.post<string>(url, body, httpOptions);
    }

    update(gamerBoardGame: GamerBoardGame): Observable<string> {
        const url = `${this._editGamerBoardGameUrl}`;
        return this.http
            .post<string>(url, JSON.stringify({ gamerBoardGameId: gamerBoardGame.BoardGameId }), httpOptions);
    }
}