import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import 'rxjs/add/operator/switchMap';
import { Subject } from "rxjs/Subject";
import "rxjs/add/operator/map";
import "rxjs/add/operator/debounceTime";

import { BoardGameService } from "./BoardGame.service";
import { BoardGame } from "./BoardGame";


@Component({
    selector: "boardGame-list",
    templateUrl: "./src/BoardGames/BoardGame-list.component.html",
})
export class BoardGameListComponent implements OnInit {
    private allBoardGames: BoardGame[];
    private searchedBoardGames: BoardGame[];
    //private selectedBoardGame: BoardGame;
    private isAdmin = false;
    private query: string = "";
    private search: Subject<string> = new Subject<string>();

    constructor(
        private boardGameService: BoardGameService,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit(): void {
        this.route.params
            .switchMap(() => this.boardGameService.getBoardGames())
            .subscribe((boardGameList: BoardGame[]) => {
                this.allBoardGames = boardGameList;
                this.searchedBoardGames = boardGameList;
            });

        this.search.debounceTime(500).map(query => {
            return query;
        }).subscribe(this.searchQuery.bind(this));
    }

    //onSelect(boardGame: BoardGame): void {
    //    this.selectedBoardGame = boardGame;
    //}

    delete(boardGame: BoardGame): void {
        this.boardGameService
            .deactivate(boardGame.Id)
            .subscribe(() => {
                this.allBoardGames = this.allBoardGames.filter(g => g !== boardGame);
                //if (this.selectedBoardGame === boardGame) {
                //    this.selectedBoardGame = null;
                //}
            });
    }

    searchQuery(query: string): void {
        //this.selectedBoardGame = null;
        if (query.length > 0) {
            this.searchedBoardGames = this.allBoardGames.filter(x => x.Name.toLowerCase().match(query.toLowerCase()));
        } else {
            this.searchedBoardGames = this.allBoardGames;
        }
    }

    gotoDetail(boardGame: BoardGame): void {
        this.router.navigate(["/boardGames", boardGame.Id]);
    }

    gotoAdd(): void {
        this.router.navigate(["/boardGame", 0]);
    }
}