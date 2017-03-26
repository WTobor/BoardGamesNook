//import { Injectable } from '@angular/core';
//import { Http } from '@angular/http';
//import { HttpHelpers } from '../http-helpers';
import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Gamer } from './gamer';

@Injectable()
export class GamerService {
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private _getGamerUrl = 'Gamer/Get';
    private _getGamerListUrl = 'Gamer/GetAll';
    private _addGamerUrl = 'Gamer/Add';
    private _editGamerUrl = 'Gamer/Edit';
    private _deleteGamerUrl = 'Gamer/Delete';

    constructor(private http: Http) { }

    getGamers(): Promise<Gamer[]> {
        const url = `${this._getGamerListUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                console.log(response.json());
                 return response.json() as Gamer[];
            })
            .catch(this.handleError);
    }

    getGamer(id: number): Promise<Gamer> {
        const url = `${this._getGamerUrl}/${id}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                console.log(response.json());
                return response.json() as Gamer;
            })
            .catch(this.handleError);
    }

    delete(id: number): Promise<void> {
        const url = `${this._deleteGamerUrl}/${id}`;
        return this.http.post(url, { headers: this.headers })
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    create(gamer: Gamer): Promise<Gamer> {
        return this.http
            .post(`${this._addGamerUrl}`, JSON.stringify(gamer), { headers: this.headers })
            .toPromise()
            .then(res => res.json().data)
            .catch(this.handleError);
    }

    update(gamer: Gamer): Promise<Gamer> {
        const url = `${this._editGamerUrl}`;
        return this.http
            .post(url, JSON.stringify(gamer) , { headers: this.headers })
            .toPromise()
            .then(() => gamer)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error(`An error occurred`, error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}