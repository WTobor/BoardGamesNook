import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Location } from "@angular/common";

import { GamerService } from "../gamers/gamer.service";
import { BoardGameService } from "../boardGames/boardGame.service";
import { Gamer } from "../gamers/gamer";
import { BoardGame } from "../boardGames/boardGame";
import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";
import { Common } from "./../Common";
import { GameTableService } from "../gameTables/gameTable.service";
import { GameTable } from "../gameTables/gameTable";
import { TableBoardGame } from "../gameTables/tableBoardGame";

@Component({
    selector: "gameResult-addMany",
    templateUrl: "./src/gameResults/gameResult-addMany.component.html",
    providers: [BoardGameService, GamerService, GameTableService]
})
export class GameResultAddManyComponent implements OnInit {
    gameResult: GameResult;
    gameResults: GameResult[];
    gamerGameTablesWithoutResults: GameTable[];
    selectedGameTable: GameTable;
    selectedGameTableId: number;
    tableBoardGames: TableBoardGame[];
    selectedTableBoardGame: BoardGame;
    selectedTableBoardGameId: number;
    tableGamers: Gamer[];
    selectedTableGamer: Gamer;
    selectedTableGamerId: number;
    currentGamerNickname: string;

    pointList: number[];
    placeList: number[];

    constructor(
        private gameResultService: GameResultService,
        private boardGameService: BoardGameService,
        private gameTableService: GameTableService,
        private gamerService: GamerService,
        private location: Location,
        private router: Router
    ) {
    }

    ngOnInit() {
        this.gameResultService.getGameResult(0)
            .subscribe((gameResult: GameResult) => {
                this.gameResult = gameResult;
            });

        this.gamerService.getCurrentGamerNickname().subscribe(nickname => {
            this.currentGamerNickname = nickname;
        });

        this.gameTableService.getGameTablesWithoutResultsByGamerNickname(this.currentGamerNickname).subscribe(
            gamerGameTablesWithoutResults => {
                this.gamerGameTablesWithoutResults = gamerGameTablesWithoutResults;
                if (this.gamerGameTablesWithoutResults != null && this.gamerGameTablesWithoutResults.length > 0) {
                    this.selectBoardGameTable(this.gamerGameTablesWithoutResults[0]);
                }
            });
    }

    selectBoardGameTable(selectedGameTable: GameTable): void {
        this.selectedGameTableId = selectedGameTable.Id;
        this.tableBoardGames = selectedGameTable.TableBoardGameList;
        this.gameTableService.getGameTable(this.selectedGameTableId).subscribe(gameTable => {
            this.gamerService.getGamers().subscribe(gamers => {
                this.tableGamers = gamers;
                this.pointList = new Array<number>(gamers.length);
                this.placeList = new Array<number>(gamers.length);
                if (gameTable.TableBoardGameList != null && gameTable.TableBoardGameList.length > 0) {
                    this.selectedTableBoardGameId = gameTable.TableBoardGameList.map(x => x.BoardGameId)[0];
                }
            });
        });
    }

    onSubmitMany(submittedForm) {
        if (submittedForm.invalid) {
            return;
        }
        this.addMany();
    }

    addMany(): void {
        const playersNumber = this.tableGamers.length;
        this.gameResults = [];
        for (let i = 0; i < playersNumber; i++) {
            this.gameResult = new GameResult;
            this.gameResult.GameTableId = this.selectedGameTableId;
            this.gameResult.BoardGameId = this.selectedTableBoardGameId;
            this.gameResult.GamerId = this.tableGamers[i].Id;
            this.gameResult.Points = this.pointList[i];
            this.gameResult.Place = this.placeList[i];
            this.gameResult.PlayersNumber = playersNumber;
            this.gameResults.push(this.gameResult);
        }

        this.gameResultService.createMany(this.gameResults)
            .subscribe(errorMessage => {
                new Common(null, null, this.router).showErrorOrReturn(errorMessage);
                this.router.navigate([""]);
                window.location.reload();
            });
    }

    goBack(): void {
        const loc = this.location;
        return new Common(loc).goBack();
    }
}