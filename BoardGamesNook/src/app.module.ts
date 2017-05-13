import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { GamersModule } from './gamers/gamers.module';
import { BoardGamesModule } from './boardGames/boardGames.module';
import { GamerBoardGamesModule } from './gamerBoardGames/gamerBoardGames.module';
import { GameTablesModule } from './gameTables/gameTables.module';

import { PageNotFoundComponent } from './not-found.component';

import { DialogService } from './dialog.service';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        GamersModule,
        BoardGamesModule,
        GamerBoardGamesModule,
        GameTablesModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent,
        PageNotFoundComponent
    ],
    providers: [
        DialogService
    ],
    bootstrap: [AppComponent]
})
export class AppModule {}