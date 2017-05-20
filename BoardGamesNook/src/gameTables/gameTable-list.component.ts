import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { GameTableService } from "./gameTable.service";
import { GameTable } from "./gameTable";

@Component({
    selector: "gameTable-list",
    templateUrl: "./src/gameTables/gameTable-list.component.html"
})
export class GameTableListComponent implements OnInit {
    gameTables: GameTable[];
    selectedGameTable: GameTable;

    constructor(
        private gameTableService: GameTableService,
        private router: Router) { }

    ngOnInit(): void {
        this.getGameTables();
    }

    onSelect(gameTable: GameTable): void {
        this.selectedGameTable = gameTable;
    }

    getGameTables(): void {
        this.gameTableService
            .getGameTables()
            .then(gameTables => this.gameTables = gameTables);
    }

    delete(gameTable: GameTable): void {
        debugger
        this.gameTableService
            .delete(gameTable.Id)
            .then(() => {
                this.gameTables = this.gameTables.filter(g => g !== gameTable);
                if (this.selectedGameTable === gameTable) { this.selectedGameTable = null; }
            });
    }

    gotoDetail(): void {
        this.router.navigate(["/gameTables", this.selectedGameTable.Id]);
    }

    gotoGameTableBoardGames(): void {
        this.router.navigate(["/gameTableBoardGames", this.selectedGameTable.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/gameTables", 0]);
    }
}