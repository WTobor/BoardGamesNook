import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Gamer } from "./gamer";

import { httpOptions } from "./../Common";
import { Observable } from "rxjs/Observable";

@Injectable()
export class GamerService {
    private _getCurrentGamerNicknameUrl = "Gamer/GetCurrentGamerNickname";
    private _getByEmailUrl = "Gamer/GetByEmail";
    private _getByNicknameUrl = "Gamer/GetByNickname";
    private _getGamerListUrl = "Gamer/GetAll";
    private _addGamerUrl = "Gamer/Add";
    private _editGamerUrl = "Gamer/Edit";
    private _deactivateGamerUrl = "Gamer/Deactivate";

    constructor(private http: HttpClient) {}

    getGamers(): Observable<Gamer[]> {
        const url = `${this._getGamerListUrl}`;
        return this.http.get<Gamer[]>(url);
    }

    getCurrentGamerNickname(): Observable<string> {
        const url = `${this._getCurrentGamerNicknameUrl}`;
        return this.http.get<string>(url);
    }

    getByEmail(email: string): Observable<Gamer> {
        if (email !== "") {
            return this.http
                .post<Gamer>(`${this._getByEmailUrl}`, JSON.stringify({ email: email }), httpOptions);
        } else {
            return new Observable<Gamer>();
        }
    }

    getByNickname(nickname: string): Observable<Gamer> {
        if (nickname !== "new") {
            return this.http
                .post<Gamer>(`${this._getByNicknameUrl}`, JSON.stringify({ nickname: nickname }), httpOptions);
        } else {
            return new Observable<Gamer>();
        }
    }

    deactivate(id: string): Observable<string> {
        const url = `${this._deactivateGamerUrl}/${id}`;
        return this.http.post<string>(url, httpOptions);
    }

    create(gamer: Gamer): Observable<string> {
        const url = `${this._addGamerUrl}`;
        return this.http
            .post<string>(url, JSON.stringify(gamer), httpOptions);
    }

    update(gamer: Gamer): Observable<string> {
        const url = `${this._editGamerUrl}`;
        return this.http
            .post<string>(url, JSON.stringify(gamer), httpOptions);
    }
}