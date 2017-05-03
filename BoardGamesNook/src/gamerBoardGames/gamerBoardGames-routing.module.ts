import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GamerBoardGameListComponent } from './gamerBoardGame-list.component';
import { GamerBoardGameDetailComponent } from './gamerBoardGame-detail.component';
import { GamerBoardGameAddComponent } from './gamerBoardGame-add.component';

const gamersRoutes: Routes = [
    { path: 'gamerBoardGames', component: GamerBoardGameListComponent },
    { path: 'gamerBoardGame/0', component: GamerBoardGameAddComponent },
    { path: 'gamerBoardGames/:id', component: GamerBoardGameDetailComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(gamersRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class GamerBoardGamesRoutingModule { }