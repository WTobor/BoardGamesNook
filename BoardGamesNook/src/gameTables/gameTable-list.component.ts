import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";

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
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit(): void {
        this.route.params
            .switchMap((params: Params) => this.gameTableService.getGameTablesByGamerNick(params["gamerNick"]))
            .subscribe((gameTableList: GameTable[]) => {
                this.gameTables = gameTableList;
            });
    }

    onSelect(gameTable: GameTable): void {
        this.selectedGameTable = gameTable;
    }

    delete(gameTable: GameTable): void {
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