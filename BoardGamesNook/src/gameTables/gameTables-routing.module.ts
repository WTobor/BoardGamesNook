import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { GameTableListComponent } from "./gameTable-list.component";
import { GameTableDetailComponent } from "./gameTable-detail.component";

const gameTablesRoutes: Routes = [
    { path: "gametables", component: GameTableListComponent },
    { path: "gametables/:gamernick", component: GameTableListComponent },
    { path: "gametable/:id", component: GameTableDetailComponent }
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