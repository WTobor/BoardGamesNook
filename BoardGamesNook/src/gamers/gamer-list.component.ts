import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { GamerService } from "./gamer.service";
import { Gamer } from "./gamer";

@Component({
    selector: "gamer-list",
    templateUrl: "./src/gamers/gamer-list.component.html",
})
export class GamerListComponent implements OnInit {
    gamers: Gamer[];
    selectedGamer: Gamer;
    isAdmin = false;

    constructor(
        private gamerService: GamerService,
        private router: Router
    ) {
    }

    ngOnInit(): void {
        this.getGamers();
    }

    onSelect(gamer: Gamer): void {
        this.selectedGamer = gamer;
    }

    getGamers(): void {
        this.gamerService
            .getGamers()
            .then(gamers => {
                this.gamers = gamers;
                this.gamerService.getCurrentGamerNick().then(nick =>
                    this.gamers = this.gamers.filter(x => x.Nick !== nick));
            });
    }

    deactivate(gamer: Gamer): void {
        this.gamerService
            .deactivate(gamer.Id)
            .then(() => {
                this.gamers = this.gamers.filter(g => g !== gamer);
                if (this.selectedGamer === gamer) {
                    this.selectedGamer = null;
                }
            });
    }

    gotoDetail(): void {
        this.router.navigate(["/gamers", this.selectedGamer.Nick]);
    }

    gotoGamerBoardGames(): void {
        this.router.navigate(["/gamerBoardGames", this.selectedGamer.Nick]);
    }
}