import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { GamerBoardGame } from "./gamerBoardGame";

import { Common } from "./../Common";

@Injectable()
export class GamerBoardGameService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getGamerBoardGameUrl = "gamerboardgame/Get";
    private _getGamerBoardGameListUrl = "gamerboardgame/GetAllByGamerNick";
    private _addGamerBoardGameUrl = "gamerboardgame/Add";
    private _editGamerBoardGameUrl = "gamerboardgame/Edit";
    private _deleteGamerBoardGameUrl = "gamerboardgame/Delete";
    private _getGamerAvailableBoardGamesUrl = "gamerboardgame/GetGamerAvailableBoardGames";

    constructor(private http: Http) { }

    getGamerBoardGames(gamernick: string): Promise<GamerBoardGame[]> {
        const url = `${this._getGamerBoardGameListUrl}/${gamernick}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as GamerBoardGame[];
            })
            .catch(ex => { return new Common().handleError(ex); });
    }

    getGamerBoardGame(id: string): Promise<GamerBoardGame> {
        if (id !== "new") {
            const url = `${this._getGamerBoardGameUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as GamerBoardGame; })
                .catch(ex => { return new Common().handleError(ex); });
        }
        else {
            var response = new GamerBoardGame;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; });
        }
    }

    getGamerAvailableBoardGames(gamernick: string): Promise<GamerBoardGame[]> {
        const url = `${this._getGamerAvailableBoardGamesUrl}/${gamernick}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.json() as GamerBoardGame[]; })
            .catch(ex => { return new Common().handleError(ex); });
    }

    delete(id: number): Promise<string> {
        const url = `${this._deleteGamerBoardGameUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    create(boardGameId: number): Promise<string> {
        const url = `${this._addGamerBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify({ boardGameId: boardGameId }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    update(gamerBoardGame: GamerBoardGame): Promise<string> {
        const url = `${this._editGamerBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify({ gamerBoardGameId: gamerBoardGame.BoardGameId }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }
}