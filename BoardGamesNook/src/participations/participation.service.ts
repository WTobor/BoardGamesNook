import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";
import "rxjs/util/isNumeric";
import { Participation } from "./participation";

@Injectable()
export class ParticipationService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private getParticipationUrl = "Participation/Get";
    private getParticipationListUrl = "Participation/GetAll";
    private getParticipationListByGamerNickUrl = "Participation/GetAllByGamerNick";
    private addParticipationUrl = "Participation/Add";
    private editParticipationUrl = "Participation/Edit";
    private deleteParticipationUrl = "Participation/Delete";

    constructor(private http: Http) {}

    getParticipationsByGamerNick(gamerNick: string): Promise<Participation[]> {
        let url = `${this.getParticipationListUrl}`;
        if (gamerNick != null && gamerNick !== "") {
            url = `${this.getParticipationListByGamerNickUrl}/${gamerNick}`;
        };

        return this.http.get(url)
            .toPromise()
            .then(response => {
                return response.json() as Participation[];
            })
            .catch(err => { return Promise.reject(err); });
    }

    getParticipation(id: number): Promise<Participation> {
        if (id > 0) {
            const url = `${this.getParticipationUrl}/${id}`;
            return this.http.get(url)
                .toPromise()
                .then(response => { return response.json() as Participation; })
                .catch(err => { return Promise.reject(err); });
        } else {
            var response = new Participation;
            return new Promise((resolve) => { resolve(response); })
                .then(response => { return response as Participation; })
                .catch(err => { return Promise.reject(err); });
        }
    }

    create(participation: Participation): Promise<string> {
        const url = `${this.addParticipationUrl}`;
        return this.http
            .post(url, JSON.stringify(participation), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    update(participation: Participation): Promise<string> {
        const url = `${this.editParticipationUrl}`;
        return this.http
            .post(url, JSON.stringify(participation), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    delete(id: number): Promise<string> {
        // id - boardGameId
        const url = `${this.deleteParticipationUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }
}