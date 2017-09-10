import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import { GameResultListComponent } from "./gameResult-list.component";
import { GameResultDetailComponent } from "./gameResult-detail.component";
import { GameResultAddComponent } from "./gameResult-add.component";

import { GameResultService } from "./gameResult.service";

import { GameResultRoutingModule } from "./gameResults-routing.module";

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        GameResultRoutingModule
    ],
    declarations: [
        GameResultListComponent,
        GameResultDetailComponent,
        GameResultAddComponent
    ],
    providers: [GameResultService]
})
export class GameResultsModule { }