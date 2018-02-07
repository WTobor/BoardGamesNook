import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";
import 'rxjs/add/operator/switchMap';

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
    selectedGamerNickname: string;
    isCurrentGamer: boolean = false;

    constructor(
        private gamerBoardGameService: GamerBoardGameService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit() {
        this.route.params
            .switchMap((params: Params) => this.gamerBoardGameService.getGamerBoardGames(params["gamerNickname"]))
            .subscribe((gamerBoardGames: GamerBoardGame[]) => this.gamerBoardGames = gamerBoardGames);
        this.route.params
            .subscribe((params: Params) => {
                this.selectedGamerNickname = params["gamerNickname"];
                this.gamerService.getCurrentGamerNickname().subscribe(nickname => {
                    if (nickname === this.selectedGamerNickname) {
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
            .deactivate(gamerBoardGame.Id)
            .subscribe(() => {
                this.gamerBoardGames = this.gamerBoardGames.filter(g => g !== gamerBoardGame);
                if (this.selectedGamerBoardGame === gamerBoardGame) { this.selectedGamerBoardGame = null; }
            });
    }

    gotoDetail(): void {
        this.router.navigate(["/gamerBoardGames", this.selectedGamerBoardGame.GamerNickname, this.selectedGamerBoardGame.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/gamerBoardGame", this.selectedGamerNickname, 0]);
    }
}