import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { GameTableListComponent } from "./gameTable-list.component";
import { GameTableDetailComponent } from "./gameTable-detail.component";
import {GameTableAddComponent} from "./gameTable-add.component";

const gameTablesRoutes: Routes = [
    { path: "gameTables", component: GameTableListComponent },
    { path: "gamerGameTablesWithoutResults/:gamerNickname", component: GameTableListComponent },
    { path: "gameTable/0", component: GameTableAddComponent },
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
export class GameTableRoutingModule {
}