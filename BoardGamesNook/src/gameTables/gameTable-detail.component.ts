import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
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
    isCurrentGamer = false;
    //TODO: add isMember to allow edit

    constructor(
        private gameTableService: GameTableService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location
    ) {
    }

    ngOnInit() {
        this.gameTableService.getGameTable(Number(this.route.snapshot.paramMap.get('id')))
            .subscribe((gameTable: GameTable) => {
                this.gameTable = gameTable;
                this.SetMinAndMaxPlayers();

                this.getAvailableTableBoardGameList(this.gameTable.Id);
                this.gamerService.getCurrentGamerNickname().subscribe(nickname => {
                    if (nickname === this.gameTable.CreatedGamerNickname) {
                        this.isCurrentGamer = true;
                    }
                });
            });
    }

    //duplicated in gameTable-add
    getAvailableTableBoardGameList(tableId: number): void {
        this.gameTableService
            .getAvailableTableBoardGameList(tableId)
            .subscribe(
                availableTableBoardGames => this.availableTableBoardGames = availableTableBoardGames
            );
    }

    //duplicated in gameTable-add
    addTableBoardGame(selectedTableBoardGameId: number): void {
        this.selectedTableBoardGame =
            this.availableTableBoardGames.filter(x => x.BoardGameId === Number(selectedTableBoardGameId))[0];
        this.gameTable.TableBoardGameList = this.gameTable.TableBoardGameList || [];
        this.gameTable.TableBoardGameList.push(this.selectedTableBoardGame);
        const index = this.availableTableBoardGames.indexOf(this.selectedTableBoardGame, 0);
        this.availableTableBoardGames.splice(index, 1);
        this.SetMinAndMaxPlayers();
    }

    private SetMinAndMaxPlayers(): void {
        this.gameTable.MinPlayers = Math.min(...this.gameTable.TableBoardGameList.map(x => x.MinBoardGamePlayers));
        this.gameTable.MaxPlayers = Math.max(...this.gameTable.TableBoardGameList.map(x => x.MaxBoardGamePlayers));
    }

    deactivate(tableBoardGame: TableBoardGame): void {
        this.gameTable.TableBoardGameList = this.gameTable.TableBoardGameList.filter(t => t !== tableBoardGame);
        this.availableTableBoardGames.push(tableBoardGame);
        if (this.selectedTableBoardGame === tableBoardGame) {
            this.selectedTableBoardGame = null;
        }
    }

    onSubmit(submittedForm) {
        if (submittedForm.invalid) {
            return;
        }
        this.save();
    }

    save(): void {
        var loc = this.location;
        this.gameTableService.update(this.gameTable)
            .subscribe(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
        
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }
}