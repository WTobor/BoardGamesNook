import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";

import { GameTableService } from "./gameTable.service";
import { GameTable } from "./gameTable";
import { GamerService } from "../gamers/gamer.service";

@Component({
    selector: "gameTable-list",
    templateUrl: "./src/gameTables/gameTable-list.component.html"
})
export class GameTableListComponent implements OnInit {
    gameTables: GameTable[];
    loadedGameTables: GameTable[];
    selectedGameTable: GameTable;
    selectedGamerNickname: string;
    isCurrentGamer: boolean = false;

    constructor(
        private gameTableService: GameTableService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.route.params
            .switchMap((params: Params) => this.gameTableService.getGameTablesByGamerNickname(params["gamerNickname"]))
            .subscribe((gameTableList: GameTable[]) => {
                this.loadedGameTables = gameTableList;
            });

        this.route.params
            .subscribe((params: Params) => {
                this.selectedGamerNickname = params["gamerNickname"];
                this.gamerService.getCurrentGamerNickname().then(nick => {
                    if (nick === this.selectedGamerNickname) {
                        this.isCurrentGamer = true;
                    };
                    if (this.selectedGamerNickname === undefined && this.loadedGameTables !== undefined) {
                        this.gameTables = this.loadedGameTables.filter(x => x.CreatedGamerNickname !== nick);
                    }
                    else {
                        this.gameTables = this.loadedGameTables;
                    }
                });
            });
    }

    onSelect(gameTable: GameTable): void {
        this.selectedGameTable = gameTable;
    }

    delete(gameTable: GameTable): void {
        this.gameTableService
            .deactivate(gameTable.Id)
            .then(() => {
                this.gameTables = this.gameTables.filter(g => g !== gameTable);
                if (this.selectedGameTable === gameTable) { this.selectedGameTable = null; }
            });
    }

    gotoDetail(): void {
        this.router.navigate(["/gameTable", this.selectedGameTable.Id]);
    }

    gotoJoin(): void {
        this.openDialog();
    }

    gotoGameTableBoardGames(): void {
        this.router.navigate(["/gameTableBoardGames", this.selectedGameTable.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/gameTable", 0]);
    }

    openDialog() {
        
    }
}