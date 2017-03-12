import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {HttpHelpers} from '../utils/HttpHelpers';
import {Observable} from 'rxjs/Observable';
import 'rxjs/Rx';

@Injectable()
export class AppServiceGamer extends HttpHelpers {

    private _getGamerUrl = 'Gamer/Get';
    private _getGamerListUrl = 'Gamer/GetAll';

    private _getGamerAddUrl = 'Gamer/Add';
    private _getTGamerEditUrl = 'Gamer/Edit';
    private _getGamerDeleteUrl = 'Gamer/Delete';

    private _gamer: Models.Gamer;
    private _gamerList: Models.Gamer[];
    
    Gamer: Models.Gamer;
    GamerList: Models.Gamer[];

    constructor(private http: Http) {
        super(http);

        this.getaction<Models.Gamer>(this._getGamerUrl).subscribe(
            result => {
                this._gamer = result;
            },
            error => this.errormsg = error);
    }

    get gamer(): Models.Gamer {
        return this._gamer;
    } 

    //get gamerList(): Models.Gamer[] {
    //    return this._gamerList;
    //}

    addGamer(gamer: Models.Gamer) {
        this.postaction(gamer, this._getGamerAddUrl).subscribe(result => {
            if (!result.haserror) {
                this.GamerList.push(result.element);
            }
        }, error => this.errormsg = error);
    }

    editGamer(gamer: Models.Gamer) {
        this.postaction(gamer, this._getTGamerEditUrl).subscribe(result => result, error => this.errormsg = error);
    }

    deleteGamer(gamer: Models.Gamer) {
        this.postaction(gamer, this._getGamerDeleteUrl).subscribe(result => {

            if (!result.haserror) {
                var index = this.GamerList.indexOf(gamer, 0);

                if (index > -1) {
                    this.GamerList.splice(index, 1);
                }
            }
        }, error => this.errormsg = error);
    }
}