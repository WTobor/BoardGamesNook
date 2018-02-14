import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { GameResultListComponent } from "./gameResult-list.component";
import { GameResultDetailComponent } from "./gameResult-detail.component";
import { GameResultAddComponent } from "./gameResult-add.component";
import {GameResultAddManyComponent} from "./gameResult-addMany.component";

const resultsRoutes: Routes = [
    { path: "gameResults", component: GameResultListComponent },
    { path: "gamerGameResults/:nickname", component: GameResultListComponent },
    { path: "gameResult/0", component: GameResultAddComponent },
    { path: "gameResults/0", component: GameResultAddManyComponent },
    { path: "gameResult/:id", component: GameResultDetailComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(resultsRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class GameResultRoutingModule {
}