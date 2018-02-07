import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { GamerBoardGame } from "./gamerBoardGame";

@Injectable()
export class GamerBoardGameService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getGamerBoardGameUrl = "GamerBoardGame/Get";
    private _getGamerBoardGameListUrl = "GamerBoardGame/GetAllByGamerNickname";
    private _addGamerBoardGameUrl = "GamerBoardGame/Add";
    private _editGamerBoardGameUrl = "GamerBoardGame/Edit";
    private _deactivateGamerBoardGameUrl = "GamerBoardGame/Deactivate";
    private _getGamerAvailableBoardGamesUrl = "GamerBoardGame/GetGamerAvailableBoardGames";

    constructor(private http: Http) { }

    getGamerBoardGames(gamerNickname: string): Promise<GamerBoardGame[]> {
        const url = `${this._getGamerBoardGameListUrl}/${gamerNickname}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as GamerBoardGame[];
            })
            .catch(err => { return Promise.reject(err); });
    }

    getGamerBoardGame(id: number): Promise<GamerBoardGame> {
        if (id > 0) {
            const url = `${this._getGamerBoardGameUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as GamerBoardGame; })
                .catch(err => { return Promise.reject(err); });
        }
        else {
            var response = new GamerBoardGame;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response as GamerBoardGame; })
                .catch(err => { return Promise.reject(err); });
        }
    }

    getGamerAvailableBoardGames(gamerNickname: string): Promise<GamerBoardGame[]> {
        const url = `${this._getGamerAvailableBoardGamesUrl}/${gamerNickname}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.json() as GamerBoardGame[]; })
            .catch(err => { return Promise.reject(err); });
    }

    deactivate(id: number): Promise<string> {
        const url = `${this._deactivateGamerBoardGameUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    create(boardGameId: number): Promise<string> {
        const url = `${this._addGamerBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify({ boardGameId: boardGameId }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    update(gamerBoardGame: GamerBoardGame): Promise<string> {
        const url = `${this._editGamerBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify({ gamerBoardGameId: gamerBoardGame.BoardGameId }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }
}