import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { GamerBoardGameListComponent } from './gamerBoardGame-list.component';
import { GamerBoardGameDetailComponent } from './gamerBoardGame-detail.component';
import { GamerBoardGameAddComponent } from './gamerBoardGame-add.component';

import { GamerBoardGameService } from './gamerBoardGame.service';

import { GamerBoardGamesRoutingModule } from './gamerBoardGames-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        GamerBoardGamesRoutingModule
    ],
    declarations: [
        GamerBoardGameListComponent,
        GamerBoardGameDetailComponent,
        GamerBoardGameAddComponent
    ],
    providers: [GamerBoardGameService]
})
export class GamerBoardGamesModule { }