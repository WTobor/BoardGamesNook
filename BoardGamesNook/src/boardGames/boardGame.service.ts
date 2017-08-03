import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { BoardGame } from "./BoardGame";

import { Common } from "./../Common";

@Injectable()
export class BoardGameService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getBoardGameUrl = "boardgame/Get";
    private _getBoardGameListkUrl = "boardgame/GetAll";
    private _addBoardGameUrl = "boardgame/Add";
    private _addBoardGameByIdUrl = "boardgame/AddById";
    private _editBoardGameUrl = "boardgame/Edit";
    private _deleteBoardGameUrl = "boardgame/Delete";

    constructor(private http: Http) { }

    getBoardGames(): Promise<BoardGame[]> {
        const url = `${this._getBoardGameListkUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as BoardGame[];
            })
            .catch(ex => { return new Common(null).handleError(ex); });
    }

    getBoardGame(id: number): Promise<BoardGame> {
        if (id !== 0) {
            const url = `${this._getBoardGameUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as BoardGame; })
                .catch(ex => { return new Common(null).handleError(ex); });
        }
        else {
            var response = new BoardGame;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; });
        }
    }

    delete(id: number): Promise<string> {
        const url = `${this._deleteBoardGameUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    create(name: string): Promise<string> {
        return this.http
            .post(`${this._addBoardGameUrl}`, JSON.stringify({ name: name }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    addSimilar(id: number): Promise<string> {
        return this.http
            .post(`${this._addBoardGameByIdUrl}`, JSON.stringify({ id: id }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    update(boardGame: BoardGame): Promise<string> {
        const url = `${this._editBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify(boardGame), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }
}