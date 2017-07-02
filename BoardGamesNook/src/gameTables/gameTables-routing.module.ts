import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { GameTableListComponent } from "./gameTable-list.component";
import { GameTableDetailComponent } from "./gameTable-detail.component";

const gameTablesRoutes: Routes = [
    { path: "gameTables/:gamerNick", component: GameTableListComponent },
    { path: "gameTables/:id", component: GameTableDetailComponent }
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