import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import { GameTableListComponent } from "./gameTable-list.component";
import { GameTableDetailComponent } from "./gameTable-detail.component";

import { GameTableService } from "./gameTable.service";

import { GameTableRoutingModule } from "./gameTables-routing.module";

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        GameTableRoutingModule
    ],
    declarations: [
        GameTableListComponent,
        GameTableDetailComponent
    ],
    providers: [GameTableService]
})
export class GameTablesModule { }