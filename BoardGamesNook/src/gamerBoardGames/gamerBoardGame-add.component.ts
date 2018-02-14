import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Location } from "@angular/common";

import { GamerBoardGameService } from "./gamerBoardGame.service";
import { GamerBoardGame } from "./gamerBoardGame";
import { Common } from "./../Common";

@Component({
    selector: "gamerBoardGame-add",
    templateUrl: "./src/gamerBoardGames/gamerBoardGame-add.component.html"
})
export class GamerBoardGameAddComponent implements OnInit {
    gamerBoardGame: GamerBoardGame;
    gamerBoardGames: GamerBoardGame[];
    selectedBoardGameId: number;

    constructor(
        private gamerBoardGameService: GamerBoardGameService,
        private route: ActivatedRoute,
        private location: Location
    ) {
    }

    ngOnInit() {
        this.gamerBoardGameService.getGamerAvailableBoardGames(this.route.snapshot.paramMap.get('gamerNickname'))
            .subscribe((gamerBoardGames: GamerBoardGame[]) => {
                this.gamerBoardGames = gamerBoardGames;
                if (this.gamerBoardGames) {
                    this.selectedBoardGameId = this.gamerBoardGames[0].BoardGameId;
                }
            });
    }

    add(): void {
        var loc = this.location;
        this.gamerBoardGameService.create(this.selectedBoardGameId)
            .subscribe(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }

    selectBoardGame(value): void {
        this.selectedBoardGameId = Number(value);
    }
}