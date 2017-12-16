import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { GamerBoardGame } from "./gamerBoardGame";

@Injectable()
export class GamerBoardGameService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private getGamerBoardGameUrl = "GamerBoardGame/Get";
    private getGamerBoardGameListUrl = "GamerBoardGame/GetAllByGamerNick";
    private addGamerBoardGameUrl = "GamerBoardGame/Add";
    private editGamerBoardGameUrl = "GamerBoardGame/Edit";
    private deleteGamerBoardGameUrl = "GamerBoardGame/Delete";
    private getGamerAvailableBoardGamesUrl = "GamerBoardGame/GetGamerAvailableBoardGames";

    constructor(private http: Http) {}

    getGamerBoardGames(gamerNick: string): Promise<GamerBoardGame[]> {
        const url = `${this.getGamerBoardGameListUrl}/${gamerNick}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as GamerBoardGame[];
            })
            .catch(err => { return Promise.reject(err); });
    }

    getGamerBoardGame(id: number): Promise<GamerBoardGame> {
        if (id > 0) {
            const url = `${this.getGamerBoardGameUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as GamerBoardGame; })
                .catch(err => { return Promise.reject(err); });
        } else {
            var response = new GamerBoardGame;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; })
                .catch(err => { return Promise.reject(err); });
        }
    }

    getGamerAvailableBoardGames(gamerNick: string): Promise<GamerBoardGame[]> {
        const url = `${this.getGamerAvailableBoardGamesUrl}/${gamerNick}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.json() as GamerBoardGame[]; })
            .catch(err => { return Promise.reject(err); });
    }

    delete(id: number): Promise<string> {
        const url = `${this.deleteGamerBoardGameUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    create(boardGameId: number): Promise<string> {
        const url = `${this.addGamerBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify({ boardGameId: boardGameId }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    update(gamerBoardGame: GamerBoardGame): Promise<string> {
        const url = `${this.editGamerBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify({ gamerBoardGameId: gamerBoardGame.BoardGameId }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }
}