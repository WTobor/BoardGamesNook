import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Location } from "@angular/common";

import { GameTableService } from "./gameTable.service";
import { GameTable } from "./gameTable";
import { Common } from "./../Common";
import { TableBoardGame } from "./tableBoardGame";
import {GamerService} from "../gamers/gamer.service";

@Component({
    selector: "gameTable-add",
    templateUrl: "./src/gameTables/gameTable-add.component.html"
})
export class GameTableAddComponent implements OnInit {
    gameTable: GameTable;
    availableTableBoardGames: TableBoardGame[];
    selectedTableBoardGame: TableBoardGame;

    constructor(
        private gameTableService: GameTableService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location
    ) {
    }

    ngOnInit() {
        this.gameTableService.getGameTable(0)
            .subscribe((gameTable: GameTable) => {
                this.gameTable = gameTable;
                this.gameTable.TableBoardGameList = null;
                this.getAvailableTableBoardGameList(0);
            });
    }

    getAvailableTableBoardGameList(tableId: number): void {
        this.gameTableService
            .getAvailableTableBoardGameList(tableId)
            .subscribe(
                availableTableBoardGames => this.availableTableBoardGames = availableTableBoardGames
            );
    }

    addTableBoardGame(selectedTableBoardGameId: number): void {
        this.selectedTableBoardGame =
            this.availableTableBoardGames.filter(x => x.BoardGameId === Number(selectedTableBoardGameId))[0];
        this.gameTable.TableBoardGameList = this.gameTable.TableBoardGameList || [];
        this.gameTable.TableBoardGameList.push(this.selectedTableBoardGame);
        const index = this.availableTableBoardGames.indexOf(this.selectedTableBoardGame, 0);
        this.availableTableBoardGames.splice(index, 1);
        //TODO: count minPlayers and maxPlayers by boardGames
    }

    onSubmit(submittedForm) {
        if (submittedForm.invalid) {
            return;
        }
        this.add();
    }

    add(): void {
        var loc = this.location;
        this.gameTableService.create(this.gameTable)
            .subscribe(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
    }

    deactivate(tableBoardGame: TableBoardGame): void {
        this.gameTable.TableBoardGameList = this.gameTable.TableBoardGameList.filter(t => t !== tableBoardGame);
        this.availableTableBoardGames.push(tableBoardGame);
        if (this.selectedTableBoardGame === tableBoardGame) {
            this.selectedTableBoardGame = null;
        }
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }
}