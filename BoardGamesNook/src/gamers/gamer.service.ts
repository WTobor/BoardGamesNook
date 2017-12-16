import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";
import { Gamer } from "./gamer";

@Injectable()
export class GamerService {
    private headers = new Headers({ "Content-Type": "application/json" });
    private getCurrentGamerNickUrl = "Gamer/GetCurrentGamerNick";
    private getByEmailUrl = "Gamer/GetByEmail";
    private getByNickUrl = "Gamer/GetByNick";
    private getGamerListUrl = "Gamer/GetAll";
    private addGamerUrl = "Gamer/Add";
    private editGamerUrl = "Gamer/Edit";
    private deactivateGamerUrl = "Gamer/Deactivate";

    constructor(private http: Http) {}

    getGamers(): Promise<Gamer[]> {
        const url = `${this.getGamerListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                var result = response.json() as Gamer[];
                return result;
            })
            .catch(err => { return Promise.reject(err); });
    }

    getCurrentGamerNick(): Promise<string> {
        const url = `${this.getCurrentGamerNickUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    getByEmail(email: string): Promise<Gamer> {
        if (email !== "") {
            return this.http
                .post(`${this.getByEmailUrl}`, JSON.stringify({ email: email }), { headers: this.headers })
                .toPromise()
                .then((response): Gamer => {
                    if (response.text() === "") {
                        return null;
                    }
                    return response.json() as Gamer;
                })
                .catch(err => { return Promise.reject(err); });
        } else {
            var response = new Gamer;
            return new Promise((resolve) => { resolve(response); })
                .then((response): Gamer => { return response as Gamer; })
                .catch(err => { return Promise.reject(err); });
        }
    }

    getByNick(nick: string): Promise<Gamer> {
        if (nick !== "new") {
            return this.http
                .post(`${this.getByNickUrl}`, JSON.stringify({ nick: nick }), { headers: this.headers })
                .toPromise()
                .then((response): Gamer => {
                    if (response.text() === "") {
                        return null;
                    }
                    return response.json() as Gamer;
                })
                .catch(err => { return Promise.reject(err); });
        } else {
            var response = new Gamer;
            return new Promise((resolve) => { resolve(response); })
                .then((response): Gamer => { return response as Gamer; })
                .catch(err => { return Promise.reject(err); });
        }
    }

    deactivate(id: string): Promise<string> {
        const url = `${this.deactivateGamerUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    create(gamer: Gamer): Promise<string> {
        const url = `${this.addGamerUrl}`;
        return this.http
            .post(url, JSON.stringify(gamer), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }

    update(gamer: Gamer): Promise<string> {
        const url = `${this.editGamerUrl}`;
        return this.http
            .post(url, JSON.stringify(gamer), { headers: this.headers })
            .toPromise()
            .then(response => { return response.text(); })
            .catch(err => { return Promise.reject(err); });
    }
}