import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { BoardGame } from "./BoardGame";
import { Observable } from "rxjs/Observable";
import {httpOptions} from "../common";


@Injectable()
export class BoardGameService {
    private _getBoardGameUrl = "BoardGame/Get";
    private _getBoardGameListUrl = "BoardGame/GetAll";
    private _addBoardGameUrl = "BoardGame/Add";
    private _addBoardGameByIdUrl = "BoardGame/AddById";
    private _editBoardGameUrl = "BoardGame/Edit";
    private _deactivateBoardGameUrl = "BoardGame/Deactivate";

    constructor(private http: HttpClient) {}

    getBoardGames(): Observable<BoardGame[]> {
        const url = `${this._getBoardGameListUrl}`;
        return this.http.get<BoardGame[]>(url);
    }

    getBoardGame(id: number): Observable<BoardGame> {
        if (id !== 0) {
            const url = `${this._getBoardGameUrl}/${id}`;
            return this.http.get<BoardGame>(url);
        } else {
            return new Observable<BoardGame>();
        }
    }

    deactivate(id: number): Observable<string> {
        const url = `${this._deactivateBoardGameUrl}/${id}`;
        return this.http.post<string> (url, httpOptions);
    }

    create(name: string): Observable<string> {
        return this.http
            .post<string> (`${this._addBoardGameUrl}`, JSON.stringify({ name: name }), httpOptions);
    }

    addSimilar(id: number): Observable<string> {
        return this.http.post<string>(`${this._addBoardGameByIdUrl}`, JSON.stringify({ id: id }), httpOptions);
    }

    update(boardGame: BoardGame): Observable<string> {
        const url = `${this._editBoardGameUrl}`;
        return this.http.post<string>(url, JSON.stringify(boardGame), httpOptions);
    }
}