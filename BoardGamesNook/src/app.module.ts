import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { LocationStrategy, HashLocationStrategy } from "@angular/common";

import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";

import { GamersModule } from "./gamers/gamers.module";
import { BoardGamesModule } from "./boardGames/boardGames.module";
import { GamerBoardGamesModule } from "./gamerBoardGames/gamerBoardGames.module";
import { GameTablesModule } from "./gameTables/gameTables.module";

import { PageNotFoundComponent } from "./not-found.component";
import { AboutComponent } from "./about/about.component";
import { WelcomeComponent } from "./welcome/welcome.component";

import { DialogService } from "./dialog.service";
import { UserService } from "./users/user.service";
import { AboutRoutingModule } from "./about/about-routing.module";
import { WelcomeRoutingModule } from "./welcome/welcome-routing.module";
import { MaterialModule } from "@angular/material";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { PopupComponent } from './popup/popup.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        GamersModule,
        BoardGamesModule,
        GamerBoardGamesModule,
        GameTablesModule,
        AppRoutingModule,
        AboutRoutingModule,
        WelcomeRoutingModule,
        MaterialModule,
        BrowserAnimationsModule
        
    ],
    declarations: [
        AppComponent,
        PageNotFoundComponent,
        AboutComponent,
        WelcomeComponent,
        PopupComponent
    ],
    providers: [
        DialogService,
        UserService,
        {
            provide: LocationStrategy, useClass: HashLocationStrategy
        }
    ],
    bootstrap: [AppComponent],
    entryComponents:[PopupComponent]
})
export class AppModule { }