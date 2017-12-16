import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";
import { GameResult } from "./gameResult";

@Injectable()
export class GameResultService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private getGameResultUrl = "GameResult/Get";
    private getByTableUrl = "GameResult/GetByTable";
    private getByNickUrl = "GameResult/GetAllByGamerNick";
    private getGameResultListUrl = "GameResult/GetAll";
    private addGameResultUrl = "GameResult/Add";
    private addGameResultListUrl = "GameResult/AddMany";
    private editGameResultUrl = "GameResult/Edit";

    constructor(private http: Http) { }

    getGameResults(): Promise<GameResult[]> {
        const url = `${this.getGameResultListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                var result = response.json() as GameResult[];
                return result;
            })
            .catch(err => { return Promise.reject(err); });
    }

    getGameResult(id: number): Promise<GameResult> {
        if (id !== 0) {
            const url = `${this.getGameResultUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then((response): GameResult => { return response.json() as GameResult; })
                .catch (err => { return Promise.reject(err); });
        }
        else {
            var response = new GameResult;
            return new Promise((resolve) => { resolve(response); })
            .then((response): GameResult => { return response as GameResult; })
            .catch (err => { return Promise.reject(err); });
        }
    }

    getByTable(table: number): Promise<GameResult> {
        return this.http
            .post(`${this.getByTableUrl}`, JSON.stringify({ table: table }), { headers: this.headers })
            .toPromise()
            .then(response => {
                if (response.text() === "") {
                    return null;
                }
                return response.json() as GameResult;
            })
            .catch(err => { return Promise.reject(err); });
    }

    getByNick(nick: string): Promise<GameResult> {
        if (nick !== "new") {
            return this.http
                .post(`${this.getByNickUrl}`, JSON.stringify({ nick: nick }), { headers: this.headers })
                .toPromise()
                .then((response): GameResult => {
                    if (response.text() === "") {
                        return null;
                    }
                    return response.json() as GameResult;
                })
                .catch(err => { return Promise.reject(err); });
        }
        else {
            var response = new GameResult;
            return new Promise((resolve) => { resolve(response); })
                .then((response): GameResult => { return response as GameResult; })
                .catch(err => { return Promise.reject(err); });
        }
    }

    create(gameResult: GameResult): Promise<string> {
        const url = `${this.addGameResultUrl}`;
        return this.http
            .post(url, JSON.stringify(gameResult), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    createMany(gameResults: GameResult[]): Promise<string> {
        const url = `${this.addGameResultListUrl}`;
        return this.http
            .post(url, JSON.stringify(gameResults), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    update(gameResult: GameResult): Promise<string> {
        const url = `${this.editGameResultUrl}`;
        return this.http
            .post(url, JSON.stringify(gameResult), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }
}