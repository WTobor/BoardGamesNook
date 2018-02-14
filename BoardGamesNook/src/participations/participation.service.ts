import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Participation } from "./participation";
import {httpOptions} from "../common";
import { Observable } from "rxjs/Observable";

@Injectable()
export class ParticipationService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getParticipationUrl = "Participation/Get";
    private _getParticipationListUrl = "Participation/GetAll";
    private _getParticipationListByGamerNicknameUrl = "Participation/GetAllByGamerNickname";
    private _addParticipationUrl = "Participation/Add";
    private _editParticipationUrl = "Participation/Edit";
    private _deactivateParticipationUrl = "Participation/Deactivate";

    constructor(private http: HttpClient) { }

    getParticipationsByGamerNickname(gamerNickname: string): Observable<Participation[]> {
        var url = `${this._getParticipationListUrl}`;
        if (gamerNickname != null && gamerNickname !== "") {
            url = `${this._getParticipationListByGamerNicknameUrl}/${gamerNickname}`;
        };

        return this.http.get<Participation[]>(url);
    }

    getParticipation(id: number): Observable<Participation> {
        if (id > 0) {
            const url = `${this._getParticipationUrl}/${id}`;
            return this.http.get<Participation>(url);
        }
        else {
            return new Observable<Participation>();
        }
    }

    create(participation: Participation): Observable<string> {
        const url = `${this._addParticipationUrl}`;
        return this.http
            .post<string>(url, JSON.stringify(participation), httpOptions);
    }

    update(participation: Participation): Observable<string> {
        const url = `${this._editParticipationUrl}`;
        return this.http
            .post<string>(url, JSON.stringify(participation), httpOptions);
    }

    deactivate(id: number): Observable<string> {
        // id - boardGameId
        const url = `${this._deactivateParticipationUrl}/${id}`;
        return this.http.post<string>(url, httpOptions);
    }
}