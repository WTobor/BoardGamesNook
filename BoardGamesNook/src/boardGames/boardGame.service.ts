import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { BoardGame } from "./BoardGame";


@Injectable()
export class BoardGameService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getBoardGameUrl = "BoardGame/Get";
    private _getBoardGameListUrl = "BoardGame/GetAll";
    private _addBoardGameUrl = "BoardGame/Add";
    private _addBoardGameByIdUrl = "BoardGame/AddById";
    private _editBoardGameUrl = "BoardGame/Edit";
    private _deactivateBoardGameUrl = "BoardGame/Deactivate";

    constructor(private http: Http) {}

    getBoardGames(): Promise<BoardGame[]> {
        const url = `${this._getBoardGameListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as BoardGame[];
            })
            .catch(err => { return Promise.reject(err); });
    }

    getBoardGame(id: number): Promise<BoardGame> {
        if (id !== 0) {
            const url = `${this._getBoardGameUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then((response): BoardGame => { return response.json() as BoardGame; })
                .catch(err => { return Promise.reject(err); });
        } else {
            var response = new BoardGame;
            return new Promise((resolve) => { resolve(response); })
                .then((response): BoardGame => { return response as BoardGame; })
                .catch(err => { return Promise.reject(err); });
        }
    }

    deactivate(id: number): Promise<string> {
        const url = `${this._deactivateBoardGameUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    create(name: string): Promise<string> {
        return this.http
            .post(`${this._addBoardGameUrl}`, JSON.stringify({ name: name }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    addSimilar(id: number): Promise<string> {
        return this.http
            .post(`${this._addBoardGameByIdUrl}`, JSON.stringify({ id: id }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    update(boardGame: BoardGame): Promise<string> {
        const url = `${this._editBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify(boardGame), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }
}