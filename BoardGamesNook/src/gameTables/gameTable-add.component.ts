import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";

import { GameTableService } from "./gameTable.service";
import { GameTable } from "./gameTable";

import { Common } from "./../Common";

@Component({
    selector: "gameTable-add",
    templateUrl: "./src/gameTables/gameTable-add.component.html"
})
export class GameTableAddComponent implements OnInit {
    gameTable: GameTable;
   
    constructor(
        private gameTableService: GameTableService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gameTableService.getGameTable(0))
            .subscribe((gameTable: GameTable) => this.gameTable = gameTable);
    }

    add(boardGameId: number, boardGameName: string, playersNumber: number, city: string, street: string, isPrivate: boolean): void {
        this.gameTable.Id = 0;
        // this.gameTable.GamerId = gamerId;
        // this.gameTable.GamerNick = gamerNick;
        this.gameTable.TableBoardGameList = [];
        this.gameTable.PlayersNumber = playersNumber;
        this.gameTable.City = city;
        this.gameTable.Street = street;
        this.gameTable.IsPrivate = isPrivate;

        var loc = this.location;
        this.gameTableService.create(this.gameTable)
            .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}