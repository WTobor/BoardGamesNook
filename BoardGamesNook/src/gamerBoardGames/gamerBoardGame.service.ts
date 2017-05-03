import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { GamerBoardGame } from './gamerBoardGame';

import { Common } from './../Common';

@Injectable()
export class GamerBoardGameService {
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private _getGamerBoardGameUrl = 'GamerBoardGame/Get';
    private _getGamerBoardGameListUrl = 'GamerBoardGame/GetAll';
    private _addGamerBoardGameUrl = 'GamerBoardGame/Add';
    private _editGamerBoardGameUrl = 'GamerBoardGame/Edit';
    private _deleteGamerBoardGameUrl = 'GamerBoardGame/Delete';

    constructor(private http: Http) { }

    getGamerBoardGames(): Promise<GamerBoardGame[]> {
        const url = `${this._getGamerBoardGameListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                console.log(response.json());
                return response.json() as GamerBoardGame[];
            })
            .catch(ex => { return new Common().handleError(ex) });
    }

    getGamerBoardGame(id: number): Promise<GamerBoardGame> {
        if (id !== 0) {
            const url = `${this._getGamerBoardGameUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as GamerBoardGame; })
                .catch(ex => { return new Common().handleError(ex) });
        }
        else {
            var response = new GamerBoardGame;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response });
        }
    }

    delete(id: number): Promise<string> {
        const url = `${this._deleteGamerBoardGameUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex) });
    }

    create(gamerBoardGame: GamerBoardGame): Promise<string> {
        const url = `${this._addGamerBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify(gamerBoardGame), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex) });
    }

    update(gamerBoardGame: GamerBoardGame): Promise<string> {
        const url = `${this._editGamerBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify(gamerBoardGame) , { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex) });
    }
}