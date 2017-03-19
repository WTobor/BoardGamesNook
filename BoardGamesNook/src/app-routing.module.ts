import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PageNotFoundComponent } from './not-found.component';

import { GamerDetailComponent } from './gamers/gamer-detail.component';
import { GamerListComponent } from './gamers/gamer-list.component';

const appRoutes: Routes = [];

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes
        )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }