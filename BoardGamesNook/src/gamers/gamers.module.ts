import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { GamerListComponent } from './gamer-list.component';
import { GamerDetailComponent } from './gamer-detail.component';
import { GamerAddComponent } from './gamer-add.component';

import { GamerService } from './gamer.service';

import { GamerRoutingModule } from './gamers-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        GamerRoutingModule
    ],
    declarations: [
        GamerListComponent,
        GamerDetailComponent,
        GamerAddComponent
    ],
    providers: [GamerService]
})
export class GamersModule { }