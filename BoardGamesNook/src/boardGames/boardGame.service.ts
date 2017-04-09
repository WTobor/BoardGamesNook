import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { BoardGame } from './BoardGame';

@Injectable()
export class BoardGameService {
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private _getBoardGameUrl = 'BoardGame/Get';
    private _getBoardGameListUrl = 'BoardGame/GetAll';
    private _addBoardGameUrl = 'BoardGame/Add';
    private _editBoardGameUrl = 'BoardGame/Edit';
    private _deleteBoardGameUrl = 'BoardGame/Delete';

    constructor(private http: Http) { }

    getBoardGames(): Promise<BoardGame[]> {
        const url = `${this._getBoardGameListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                console.log(response.json());
                return response.json() as BoardGame[];
            })
            .catch(this.handleError);
    }

    getBoardGame(id: number): Promise<BoardGame> {
        if (id != 0) {
            const url = `${this._getBoardGameUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => {
                    console.log(response.json());
                    return response.json() as BoardGame;
                })
                .catch(this.handleError);
        }
        else {
            var response = new BoardGame;
            return new Promise((resolve, reject) => {
                resolve(response);
            }).then(response => { return response });
        }
    }

    delete(id: number): Promise<void> {
        const url = `${this._deleteBoardGameUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    create(name: string): Promise<BoardGame> {
        return this.http
            .post(`${this._addBoardGameUrl}`, JSON.stringify(name), { headers: this.headers })
            .toPromise()
            .then(res => res.json().data)
            .catch(this.handleError);
    }

    update(BoardGame: BoardGame): Promise<BoardGame> {
        const url = `${this._editBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify(BoardGame), { headers: this.headers })
            .toPromise()
            .then(() => BoardGame)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error(`An error occurred`, error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}