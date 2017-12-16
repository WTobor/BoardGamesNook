import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";
import { GameTable } from "./gameTable";
import { TableBoardGame } from "./tableBoardGame";

@Injectable()
export class GameTableService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private getGameTableUrl = "GameTable/Get";
    private getGameTableListUrl = "GameTable/GetAll";
    private getGameTableListByGamerNickUrl = "GameTable/GetAllByGamerNick";
    private getAvailableTableBoardGameListUrl = "GameTable/GetAvailableTableBoardGameList";
    private addGameTableUrl = "GameTable/Add";
    private editGameTableUrl = "GameTable/Edit";
    private deleteGameTableUrl = "GameTable/Delete";

    constructor(private http: Http) {}

    getAvailableTableBoardGameList(tableId): Promise<TableBoardGame[]> {
        const url = `${this.getAvailableTableBoardGameListUrl}/${tableId}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                console.log(response.json());
                return response.json() as TableBoardGame[];
            })
            .catch(err => { return Promise.reject(err); });
    }

    getGameTablesByGamerNick(gamerNick: string): Promise<GameTable[]> {
        let url = `${this.getGameTableListUrl}`;
        if (gamerNick != null && gamerNick !== "") {
            url = `${this.getGameTableListByGamerNickUrl}/${gamerNick}`;
        };

        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as GameTable[];
            })
            .catch(err => { return Promise.reject(err); });
    }

    getGameTable(id: number): Promise<GameTable> {
        if (id > 0) {
            const url = `${this.getGameTableUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then((response): GameTable => { return response.json() as GameTable; })
                .catch(err => { return Promise.reject(err); });
        } else {
            var response = new GameTable;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response as GameTable; })
                .catch(err => { return Promise.reject(err); });
        }
    }

    delete(id: number): Promise<string> {
        // id - boardGameId
        const url = `${this.deleteGameTableUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    create(gameTable: GameTable): Promise<string> {
        const url = `${this.addGameTableUrl}`;
        return this.http
            .post(url, JSON.stringify(gameTable), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    update(gameTable: GameTable): Promise<string> {
        const url = `${this.editGameTableUrl}`;
        return this.http
            .post(url, JSON.stringify(gameTable), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }
}