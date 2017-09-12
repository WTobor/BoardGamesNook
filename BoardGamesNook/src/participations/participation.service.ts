import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { Participation } from "./participation";

import { Common } from "./../Common";

@Injectable()
export class ParticipationService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getParticipationUrl = "Participation/Get";
    private _getParticipationListUrl = "Participation/GetAll";
    private _getParticipationListByGamerNickUrl = "Participation/GetAllByGamerNick";
    private _addParticipationUrl = "Participation/Add";
    private _editParticipationUrl = "Participation/Edit";
    private _deleteParticipationUrl = "Participation/Delete";

    constructor(private http: Http) { }

    getParticipationsByGamerNick(gamerNick: string): Promise<Participation[]> {
        var url = `${this._getParticipationListUrl}`;
        if (gamerNick != null && gamerNick !== "") {
            url = `${this._getParticipationListByGamerNickUrl}/${gamerNick}`;
        };

        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as Participation[];
            })
            .catch (err => { return Promise.reject(err); });
    }

    getParticipation(id: number): Promise<Participation> {
        if (id > 0) {
            const url = `${this._getParticipationUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as Participation; })
                .catch (err => { return Promise.reject(err); });
        }
        else {
            var response = new Participation;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response as Participation; })
                .catch (err => { return Promise.reject(err); });
        }
    }

    create(participation: Participation): Promise<string> {
        const url = `${this._addParticipationUrl}`;
        return this.http
            .post(url, JSON.stringify(participation), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch (err => { return Promise.reject(err); });
    }

    update(participation: Participation): Promise<string> {
        const url = `${this._editParticipationUrl}`;
        return this.http
            .post(url, JSON.stringify(participation), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch (err => { return Promise.reject(err); });
    }

    delete(id: number): Promise<string> {
        // id - boardGameId
        const url = `${this._deleteParticipationUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch (err => { return Promise.reject(err); });
    }
}