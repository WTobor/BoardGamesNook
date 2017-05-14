import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { GamerListComponent } from "./gamer-list.component";
import { GamerDetailComponent } from "./gamer-detail.component";
import { GamerAddComponent } from "./gamer-add.component";

const gamersRoutes: Routes = [
    { path: "gamers", component: GamerListComponent },
    { path: "gamer/0", component: GamerAddComponent },
    { path: "gamers/:id", component: GamerDetailComponent }
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