import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { GameTableListComponent } from "./gameTable-list.component";
import { GameTableDetailComponent } from "./gameTable-detail.component";

const gameTablesRoutes: Routes = [
    { path: "gameTables", component: GameTableListComponent },
    { path: "gameTables/:gamerNick", component: GameTableListComponent },
    { path: "gameTable/:id", component: GameTableDetailComponent }
    // TODO: add with gamerID
];

@NgModule({
    imports: [
        RouterModule.forChild(gameTablesRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class GameTableRoutingModule { }