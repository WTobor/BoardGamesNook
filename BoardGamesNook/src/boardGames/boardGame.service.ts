import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { BoardGame } from "./BoardGame";


@Injectable()
export class BoardGameService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private getBoardGameUrl = "BoardGame/Get";
    private getBoardGameListUrl = "BoardGame/GetAll";
    private addBoardGameUrl = "BoardGame/Add";
    private addBoardGameByIdUrl = "BoardGame/AddById";
    private editBoardGameUrl = "BoardGame/Edit";
    private deleteBoardGameUrl = "BoardGame/Delete";

    constructor(private http: Http) {}

    getBoardGames(): Promise<BoardGame[]> {
        const url = `${this.getBoardGameListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as BoardGame[];
            })
            .catch(err => { return Promise.reject(err); });
    }

    getBoardGame(id: number): Promise<BoardGame> {
        if (id !== 0) {
            const url = `${this.getBoardGameUrl}/${id}`;
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

    delete(id: number): Promise<string> {
        const url = `${this.deleteBoardGameUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    create(name: string): Promise<string> {
        return this.http
            .post(`${this.addBoardGameUrl}`, JSON.stringify({ name: name }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    addSimilar(id: number): Promise<string> {
        return this.http
            .post(`${this.addBoardGameByIdUrl}`, JSON.stringify({ id: id }), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    update(boardGame: BoardGame): Promise<string> {
        const url = `${this.editBoardGameUrl}`;
        return this.http
            .post(url, JSON.stringify(boardGame), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }
}