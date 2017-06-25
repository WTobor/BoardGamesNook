import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";

import { GameTableService } from "./gameTable.service";
import { GameTable } from "./gameTable";

import { Common } from "./../Common";
import { TableBoardGame } from "./tableBoardGame";
import { GamerService } from "../gamers/gamer.service";

@Component({
    selector: "gameTable-detail",
    templateUrl: "./src/gameTables/gameTable-detail.component.html"
})
export class GameTableDetailComponent implements OnInit {
    gameTable: GameTable;
    availableTableBoardGames: TableBoardGame[];
    selectedTableBoardGame: TableBoardGame;
    isCurrentGamer: boolean = false;

    constructor(
        private gameTableService: GameTableService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gameTableService.getGameTable(Number(params["id"])))
            .subscribe((gameTable: GameTable) => {
                this.gameTable = gameTable;
                this.getAvailableTableBoardGameList(this.gameTable.Id);
                this.gamerService.getCurrentGamerNick().then(nick => {
                    if (nick === this.gameTable.GamerNick) {
                        this.isCurrentGamer = true;
                    }
                });
            });
    }

    getAvailableTableBoardGameList(tableId: number): void {
        this.gameTableService
            .getAvailableTableBoardGameList(tableId)
            .then(
            availableTableBoardGames => this.availableTableBoardGames = availableTableBoardGames
            );
    }

    addTableBoardGame(selectedTableBoardGameId: number): void {
        this.selectedTableBoardGame = this.availableTableBoardGames.filter(x => x.BoardGameId === Number(selectedTableBoardGameId))[0];
        this.gameTable.TableBoardGameList = this.gameTable.TableBoardGameList || [];
        this.gameTable.TableBoardGameList.push(this.selectedTableBoardGame);
        var index = this.availableTableBoardGames.indexOf(this.selectedTableBoardGame, 0);
        this.availableTableBoardGames.splice(index, 1);
        //TODO: count minPlayers and maxPlayers by boardGames
    }

    delete(tableBoardGame: TableBoardGame): void {
        this.gameTable.TableBoardGameList = this.gameTable.TableBoardGameList.filter(t => t !== tableBoardGame);
        this.availableTableBoardGames.push(tableBoardGame);
        if (this.selectedTableBoardGame === tableBoardGame) { this.selectedTableBoardGame = null; }
    }

    save(): void {
        var loc = this.location;
        if (this.gameTable.Id === 0) {
            this.gameTableService.create(this.gameTable)
                .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
        }
        else {
            this.gameTableService.update(this.gameTable)
                .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
        }
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}