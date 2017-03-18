import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GamerListComponent } from './gamer-list.component';
import { GamerDetailComponent } from './gamer-detail.component';

const gamersRoutes: Routes = [
    { path: 'gamers', component: GamerListComponent },
    { path: 'gamer/:id', component: GamerDetailComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(gamersRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class GamerRoutingModule { }