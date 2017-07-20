import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import { ParticipationListComponent } from "./participation-list.component";
import { ParticipationDetailComponent } from "./participation-detail.component";

import { ParticipationService } from "./participation.service";

import { ParticipationRoutingModule } from "./participations-routing.module";

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ParticipationRoutingModule
    ],
    declarations: [
        ParticipationListComponent,
        ParticipationDetailComponent
    ],
    providers: [ParticipationService]
})
export class ParticipationsModule { }