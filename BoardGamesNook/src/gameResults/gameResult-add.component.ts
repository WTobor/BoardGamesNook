import { GamerService } from "../gamers/gamer.service";
import { BoardGameService } from "../boardGames/boardGame.service";
import { Gamer } from "../gamers/gamer";
import { BoardGame } from "../boardGames/boardGame";
import "rxjs/add/operator/switchMap";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router, Params } from "@angular/router";
import { Location } from "@angular/common";

import { GameResultService } from "./gameResult.service";
import { GameResult } from "./gameResult";

import { Common } from "./../Common";
import {GameTableService} from "../gameTables/gameTable.service";
import {GameTable} from "../gameTables/gameTable";
import {TableBoardGame} from "../gameTables/tableBoardGame";

@Component({
    selector: "gameResult-add",
    templateUrl: "./src/gameResults/gameResult-add.component.html",
    providers: [BoardGameService, GamerService, GameTableService]
})
export class GameResultAddComponent implements OnInit {
    gameResult: GameResult;
    availableBoardGames: BoardGame[];
    availableGamers: Gamer[];
    selectedBoardGame: BoardGame;
    selectedBoardGameId: number;
    selectedGamerId: string;
    gamerGameTables: GameTable[];
    selectedGameTable: GameTable;
    selectedGameTableId: number;
    tableBoardGames: TableBoardGame[];
    selectedTableBoardGame: BoardGame;
    selectedTableBoardGameId: number;
    tableGamers: Gamer[];
    selectedTableGamer: Gamer;
    selectedTableGamerId: number;
    currentGamerNick: string;

    constructor(
        private gameResultService: GameResultService,
        private boardGameService: BoardGameService,
        private gameTableService: GameTableService,
        private gamerService: GamerService,
        private route: ActivatedRoute,
        private location: Location,
        private router: Router
    ) { }

    ngOnInit() {
        this.route.params
            .switchMap(() => this.gameResultService.getGameResult(0))
            .subscribe((gameResult: GameResult) => {
                this.gameResult = gameResult;
            });

        this.boardGameService.getBoardGames().then(
            response => {
                this.availableBoardGames = response;
            }
        );
        this.gamerService.getGamers().then(
            response => {
                this.availableGamers = response;
            }
        );
        this.gamerService.getCurrentGamerNick().then(nick => {
            this.currentGamerNick = nick;
        });

        this.gameTableService.getGameTablesByGamerNick(this.currentGamerNick).then(gamerGameTables => {
                this.gamerGameTables = gamerGameTables;
            }
        );
    }

    selectBoardGame(value): void {
        this.selectedBoardGameId = Number(value);
    }

    selectGamer(value): void {
        this.selectedGamerId = value;
    }

    selectBoardGameTable(value): void {
        this.selectedGameTableId = Number(value);
        this.gameTableService.getAvailableTableBoardGameList(this.selectedGameTableId).then(tableBoardGames => {
                this.tableBoardGames = tableBoardGames;
        });
        this.gameTableService.getGameTable(this.selectedGameTableId).then(gameTable => {
            this.tableGamers = gameTable.TableGamerList;
        });
    }

    selectTableBoardGame(value): void {
        this.selectedTableBoardGameId = Number(value);
    }



    add(points: number, place: number, playersNumber: number): void {
        debugger
        this.gameResult = new GameResult;
        this.gameResult.BoardGameId = this.selectedBoardGameId;
        this.gameResult.GamerId = this.selectedGamerId;
        this.gameResult.Points = points;
        this.gameResult.Place = place;
        this.gameResult.PlayersNumber = playersNumber;

        this.gameResultService.create(this.gameResult)
            .then(errorMessage => {
                new Common(null, this.router).showErrorOrReturn(errorMessage);
                this.router.navigate([""]);
                window.location.reload();
            });
    }

    addMany(gamerId: number[], points: number[], place: number[], playersNumber: number): void {
        for (let i = 1; i < 100; i++)
        debugger
        this.gameResult = new GameResult;
        this.gameResult.BoardGameId = this.selectedBoardGameId;
        this.gameResult.GamerId = this.selectedGamerId;
        this.gameResult.Points = points;
        this.gameResult.Place = place;
        this.gameResult.PlayersNumber = playersNumber;

        this.gameResultService.create(this.gameResult)
            .then(errorMessage => {
                new Common(null, this.router).showErrorOrReturn(errorMessage);
                this.router.navigate([""]);
                window.location.reload();
            });
    }
}