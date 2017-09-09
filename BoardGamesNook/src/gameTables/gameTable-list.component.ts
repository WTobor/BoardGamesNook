import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";

import { GameTableService } from "./gameTable.service";
import { GameTable } from "./gameTable";
import { GamerService } from "../gamers/gamer.service";

//import { MdDialog, MdDialogRef } from "@angular/material";
import { PopupComponent } from "../popup/popup.component";

@Component({
    selector: "gameTable-list",
    templateUrl: "./src/gameTables/gameTable-list.component.html"
})
export class GameTableListComponent implements OnInit {
    gameTables: GameTable[];
    loadedGameTables: GameTable[];
    selectedGameTable: GameTable;
    selectedGamerNick: string;
    isCurrentGamer: boolean = false;

    //dialogRef: MdDialogRef<PopupComponent>;

    constructor(
        private gameTableService: GameTableService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private router: Router
        //public dialog: MdDialog
    ) { }

    ngOnInit(): void {
        this.route.params
            .switchMap((params: Params) => this.gameTableService.getGameTablesByGamerNick(params["gamerNick"]))
            .subscribe((gameTableList: GameTable[]) => {
                this.loadedGameTables = gameTableList;
            });

        this.route.params
            .subscribe((params: Params) => {
                this.selectedGamerNick = params["gamerNick"];
                this.gamerService.getCurrentGamerNick().then(nick => {
                    if (nick === this.selectedGamerNick) {
                        this.isCurrentGamer = true;
                    };
                    if (this.selectedGamerNick === undefined && this.loadedGameTables !== undefined) {
                        this.gameTables = this.loadedGameTables.filter(x => x.GamerNick !== nick);
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
            .delete(gameTable.Id)
            .then(() => {
                this.gameTables = this.gameTables.filter(g => g !== gameTable);
                if (this.selectedGameTable === gameTable) { this.selectedGameTable = null; }
            });
    }

    gotoDetail(): void {
        this.router.navigate(["/gameTable", this.selectedGameTable.Id]);
    }

    gotoJoin(): void {
        this.openDialog()
    }

    gotoGameTableBoardGames(): void {
        this.router.navigate(["/gameTableBoardGames", this.selectedGameTable.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/gameTable", 0]);
    }

    openDialog() {
        //this.dialogRef = this.dialog.open(PopupComponent);
        //this.dialogRef.afterClosed().subscribe((result) => {
        //    console.log(result);
        //});
    }
}