import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Location } from "@angular/common";

import { BoardGameService } from "./BoardGame.service";
import { BoardGame } from "./BoardGame";
import { Common } from "./../Common";
import {DialogsService} from "../dialogs/confirm-dialog.service";

@Component({
    selector: "boardGame-detail",
    templateUrl: "./src/BoardGames/BoardGame-detail.component.html"
})
export class BoardGameDetailComponent implements OnInit {
    boardGame: BoardGame;
    urlParameter: number;

    constructor(
        private boardGameService: BoardGameService,
        private route: ActivatedRoute,
        private location: Location,
        private dialogsService: DialogsService
    ) {
    }

    ngOnInit() {
        this.boardGameService.getBoardGame(Number(this.route.snapshot.paramMap.get("id")))
            .subscribe((boardGame: BoardGame) => this.boardGame = boardGame);
    }

    onSubmit(submittedForm) {
        if (submittedForm.invalid) {
            return;
        }
        this.save();
    }

    save(): void {
        var loc = this.location;
        this.boardGameService.update(this.boardGame)
            .subscribe(errorMessage => { new Common(loc, this.dialogsService).showErrorOrGoBack(errorMessage); });
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }
}