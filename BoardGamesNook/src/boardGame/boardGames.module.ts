import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { BoardGameListComponent } from './BoardGame-list.component';
import { BoardGameDetailComponent } from './BoardGame-detail.component';
import { BoardGameAddComponent } from './BoardGame-add.component';

import { BoardGameService } from './BoardGame.service';

import { BoardGameRoutingModule } from './BoardGames-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        BoardGameRoutingModule
    ],
    declarations: [
        BoardGameListComponent,
        BoardGameDetailComponent,
        BoardGameAddComponent
    ],
    providers: [BoardGameService]
})
export class BoardGamesModule { }