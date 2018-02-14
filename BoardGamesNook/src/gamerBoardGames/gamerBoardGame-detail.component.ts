import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Location } from "@angular/common";

import { GamerBoardGameService } from "./gamerBoardGame.service";
import { GamerBoardGame } from "./gamerBoardGame";
import { Common } from "./../Common";

@Component({
    selector: "gamerBoardGame-detail",
    templateUrl: "./src/gamerBoardGames/gamerBoardGame-detail.component.html"
})
export class GamerBoardGameDetailComponent implements OnInit {
    gamerBoardGame: GamerBoardGame;

    constructor(
        private gamerBoardGameService: GamerBoardGameService,
        private route: ActivatedRoute,
        private location: Location
    ) {
    }

    ngOnInit() {
        this.gamerBoardGameService.getGamerBoardGame(Number(this.route.snapshot.paramMap.get('id')))
            .subscribe((gamerBoardGame: GamerBoardGame) => this.gamerBoardGame = gamerBoardGame);
    }

    save(): void {
        var loc = this.location;
        this.gamerBoardGameService.update(this.gamerBoardGame)
            .subscribe(errorMessage => { new Common(loc).showErrorOrGoBack(errorMessage); });
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }
}