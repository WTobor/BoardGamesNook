import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GameTableListComponent } from './gameTable-list.component';
import { GameTableDetailComponent } from './gameTable-detail.component';
import { GameTableAddComponent } from './gameTable-add.component';

const gameTablesRoutes: Routes = [
    { path: 'gameTables', component: GameTableListComponent },
    { path: 'gameTable/0', component: GameTableAddComponent },
    { path: 'gameTables/:id', component: GameTableDetailComponent }
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