import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { ParticipationListComponent } from "./participation-list.component";
import { ParticipationDetailComponent } from "./participation-detail.component";

const participationsRoutes: Routes = [
    { path: "participations", component: ParticipationListComponent },
    { path: "participations/:gamerNick", component: ParticipationListComponent },
    { path: "participation/:id", component: ParticipationDetailComponent }
    // TODO: add with gamerID
];

@NgModule({
    imports: [
        RouterModule.forChild(participationsRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class ParticipationRoutingModule { }