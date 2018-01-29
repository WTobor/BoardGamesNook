import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { GamerBoardGameListComponent } from "./gamerBoardGame-list.component";
import { GamerBoardGameDetailComponent } from "./gamerBoardGame-detail.component";
import { GamerBoardGameAddComponent } from "./gamerBoardGame-add.component";

const gamersRoutes: Routes = [
    { path: "gamerBoardGames/:gamerNickname", component: GamerBoardGameListComponent },
    { path: "gamerBoardGame/:gamerNickname/new", component: GamerBoardGameAddComponent },
    { path: "gamerBoardGames/:gamerNickname/:id", component: GamerBoardGameDetailComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(gamersRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class GamerBoardGamesRoutingModule {
}