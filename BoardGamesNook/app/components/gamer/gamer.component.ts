import {Component} from '@angular/core';
import {NgControl} from '@angular/common';
import {AppServiceGamer} from '../../services/app.service.gamer';

@Component({
    selector: 'gamer',
    templateUrl: './app/components/gamer/gamer.component.html',
    styleUrls: ['./app/components/gamer/gamer.component.css']
})
export class GamerComponent {
    constructor(private _appService: AppServiceGamer) {
    }

    get gamer(): Models.Gamer {
        return this._appService.gamer;
    }

    get gamerList(): Models.Gamer[] {
        return this._appService.GamerList;
    }

    gamerNick: string;
    gamerName: string;
    gamerSurname: string;
    gamerAge: number;
    gamerCity: string;
    gamerStreet: string;
    gamerActive: boolean = true;

    get hasError() {
        return this._appService.haserror;
    }

    get errorMsg() {
        return this._appService.errormsg;
    }

    hideError() {
        this._appService.errormsg = null;
    }

    deactivateGamer(gamer: Models.Gamer) {
        gamer.Active = false;

        this._appService.editGamer(gamer);
    }

    addGamer(item: NgControl) {
        if (item.valid) {
            this._appService.addGamer({
                Nick: this.gamerNick,
                Name: this.gamerName,
                Surname: this.gamerSurname,
                Age: this.gamerAge,
                City: this.gamerCity,
                Street: this.gamerStreet,
                Active: true
            });

            this.gamerNick = "";
            this.gamerName = "";
            this.gamerSurname = "";
            this.gamerAge = 0;
            this.gamerCity = "";
            this.gamerStreet = "";
        }
    }

    deleteGamer(gamer: Models.Gamer) {
        //if (confirm("Are you sure to delete selected gamer ?")) {
        this._appService.deleteGamer(gamer);
        //}
    }
}