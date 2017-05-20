import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { PageNotFoundComponent } from "./not-found.component";
import { LoginComponent } from "./account/login.component";
import { RegisterComponent } from "./account/register.component";

import { GamerAddComponent } from "./gamers/gamer-add.component";
import { GamerDetailComponent } from "./gamers/gamer-detail.component";
import { GamerListComponent } from "./gamers/gamer-list.component";

import { BoardGameAddComponent } from "./boardGames/boardGame-add.component";
import { BoardGameDetailComponent } from "./boardGames/boardGame-detail.component";
import { BoardGameListComponent } from "./boardGames/boardGame-list.component";

import { GamerBoardGameAddComponent } from "./gamerBoardGames/gamerBoardGame-add.component";
import { GamerBoardGameDetailComponent } from "./gamerBoardGames/gamerBoardGame-detail.component";
import { GamerBoardGameListComponent } from "./gamerBoardGames/gamerBoardGame-list.component";

import { GameTableDetailComponent } from "./gameTables/gameTable-detail.component";
import { GameTableListComponent } from "./gameTables/gameTable-list.component";

const appRoutes: Routes = [];

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes
        )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }