import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import "rxjs/add/operator/toPromise";

import { Participation } from "./participation";

import { Common } from "./../Common";

@Injectable()
export class ParticipationService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private _getParticipationUrl = "participation/Get";
    private _getParticipationListUrl = "participation/GetAll";
    private _getParticipationListByGamerNickUrl = "participation/GetAllByGamerNick";
    private _addParticipationUrl = "participation/Add";
    private _editParticipationUrl = "participation/Edit";
    private _deleteParticipationUrl = "participation/Delete";

    constructor(private http: Http) { }

    getParticipationsByGamerNick(gamernick: string): Promise<Participation[]> {
        var url = `${this._getParticipationListUrl}`;
        if (gamernick != null && gamernick !== "") {
            url = `${this._getParticipationListByGamerNickUrl}/${gamernick}`;
        };

        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as Participation[];
            })
            .catch(ex => { return new Common().handleError(ex); });
    }

    getParticipation(id: number): Promise<Participation> {
        if (id > 0) {
            const url = `${this._getParticipationUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as Participation; })
                .catch(ex => { return new Common().handleError(ex); });
        }
        else {
            var response = new Participation;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response; });
        }
    }

    create(participation: Participation): Promise<string> {
        const url = `${this._addParticipationUrl}`;
        return this.http
            .post(url, JSON.stringify(participation), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    update(participation: Participation): Promise<string> {
        const url = `${this._editParticipationUrl}`;
        return this.http
            .post(url, JSON.stringify(participation), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }

    delete(id: number): Promise<string> {
        // id - boardGameId
        const url = `${this._deleteParticipationUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(ex => { return new Common().handleError(ex); });
    }
}