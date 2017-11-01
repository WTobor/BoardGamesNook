import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Location } from "@angular/common";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { GameTableService } from "./gameTable.service";
import { GameTable } from "./gameTable";

import { Common } from "./../Common";
import { TableBoardGame } from "./tableBoardGame";
import { GamerService } from "../gamers/gamer.service";

@Component({
    selector: "gameTable-detail",
    templateUrl: "./src/gameTables/gameTable-detail.component.html"
})
export class GameTableDetailComponent {
    form: FormGroup;

    gameTable: GameTable;
    availableTableBoardGames: TableBoardGame[];
    selectedTableBoardGame: TableBoardGame;
    isCurrentGamer: boolean = false;
    isCreated: boolean = false;

    constructor(
        private fb: FormBuilder, 
        private gameTableService: GameTableService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location) {

        this.form = fb.group({
            gameTableName: ['', [Validators.required]],
            gameTableMinPlayers: [1, [Validators.required]]
        });

        this.route.params
            .switchMap((params: Params) => this.gameTableService.getGameTable(Number(params["id"])))
            .subscribe((gameTable: GameTable) => {
                debugger
                this.gameTable = gameTable;
                if (this.gameTable.Id == undefined) {
                    this.getAvailableTableBoardGameList(0);
                    this.isCurrentGamer = true;
                    this.isCreated = false;
                }
                else {
                    this.getAvailableTableBoardGameList(this.gameTable.Id);
                    this.gamerService.getCurrentGamerNick().then(nick => {
                        if (nick === this.gameTable.GamerNick) {
                            this.isCurrentGamer = true;
                        }
                    });
                    this.isCreated = true;
                }
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
        if (this.form.valid) {
            var loc = this.location;
            if (this.gameTable.Id === undefined) {
                this.gameTableService.create(this.gameTable)
                    .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
            } else {
                this.gameTableService.update(this.gameTable)
                    .then(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
            }
        }
    }

    goBack(): void {
        var loc = this.location;
        return new Common(loc).goBack();
    }
}