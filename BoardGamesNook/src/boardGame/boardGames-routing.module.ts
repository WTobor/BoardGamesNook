import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BoardGameListComponent } from './BoardGame-list.component';
import { BoardGameDetailComponent } from './BoardGame-detail.component';
import { BoardGameAddComponent } from './BoardGame-add.component';

const BoardGamesRoutes: Routes = [
    { path: 'BoardGames', component: BoardGameListComponent },
    { path: 'BoardGame/0', component: BoardGameAddComponent },
    { path: 'BoardGames/:id', component: BoardGameDetailComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(BoardGamesRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class BoardGameRoutingModule { }