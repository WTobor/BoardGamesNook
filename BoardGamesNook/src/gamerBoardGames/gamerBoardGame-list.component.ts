import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";

import { GamerBoardGameService } from "./gamerBoardGame.service";
import { GamerBoardGame } from "./gamerBoardGame";
import { GamerService } from "../gamers/gamer.service";

@Component({
    selector: "gamerBoardGame-list",
    templateUrl: "./src/gamerBoardGames/gamerBoardGame-list.component.html",
})
export class GamerBoardGameListComponent implements OnInit {
    gamerBoardGames: GamerBoardGame[];
    selectedGamerBoardGame: GamerBoardGame;
    selectedGamerNick: string;
    isCurrentGamer: boolean = false;

    constructor(
        private gamerBoardGameService: GamerBoardGameService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gamerBoardGameService.getGamerBoardGames(params["gamerNick"]))
            .subscribe((gamerBoardGames: GamerBoardGame[]) => this.gamerBoardGames = gamerBoardGames);

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

    onSelect(gamerBoardGame: GamerBoardGame): void {
        this.selectedGamerBoardGame = gamerBoardGame;
    }

    delete(gamerBoardGame: GamerBoardGame): void {
        this.gamerBoardGameService
            .delete(gamerBoardGame.BoardGameId)
            .then(() => {
                this.gamerBoardGames = this.gamerBoardGames.filter(g => g !== gamerBoardGame);
                if (this.selectedGamerBoardGame === gamerBoardGame) { this.selectedGamerBoardGame = null; }
            });
    }

    gotoDetail(): void {
        this.router.navigate(["/gamerBoardGames", this.selectedGamerBoardGame.GamerNick, this.selectedGamerBoardGame.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/gamerBoardGame", this.selectedGamerNick, "new"]);
    }
}