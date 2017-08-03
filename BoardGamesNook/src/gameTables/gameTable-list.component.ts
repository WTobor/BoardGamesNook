import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";

import { GameTableService } from "./gameTable.service";
import { GameTable } from "./gameTable";
import {GamerService} from "../gamers/gamer.service";

@Component({
    selector: "gameTable-list",
    templateUrl: "./src/gameTables/gameTable-list.component.html"
})
export class GameTableListComponent implements OnInit {
    gameTables: GameTable[];
    selectedGameTable: GameTable;
    selectedGamerNick: string;
    isCurrentGamer: boolean = false;

    constructor(
        private gameTableService: GameTableService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit(): void {
        this.route.params
            .switchMap((params: Params) => this.gameTableService.getGameTablesByGamerNick(params["gamerNick"]))
            .subscribe((gameTableList: GameTable[]) => {
                this.gameTables = gameTableList;
            });

        this.route.params
            .subscribe((params: Params) => {
                this.selectedGamerNick = params["gamerNick"];
                this.gamerService.getCurrentGamerNick().then(nick => {
                    if (nick === this.selectedGamerNick) {
                        this.isCurrentGamer = true;
                    }
                });
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
        this.router.navigate(["/gametable", this.selectedGameTable.Id]);
    }

    gotoJoin(): void {
        this.router.navigate(["/gametable/join/", this.selectedGameTable.Id]);
    }

    gotoGameTableBoardGames(): void {
        this.router.navigate(["/gametableboardgames", this.selectedGameTable.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/gametable", 0]);
    }
}