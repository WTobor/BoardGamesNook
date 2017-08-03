import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { BoardGameListComponent } from "./BoardGame-list.component";
import { BoardGameDetailComponent } from "./BoardGame-detail.component";
import { BoardGameAddComponent } from "./BoardGame-add.component";

const boardGamesRoutes: Routes = [
    { path: "boardgames", component: BoardGameListComponent },
    { path: "boardgame/0", component: BoardGameAddComponent },
    { path: "boardgames/:id", component: BoardGameDetailComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(boardGamesRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class BoardGameRoutingModule { }