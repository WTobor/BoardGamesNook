import {enableProdMode} from '@angular/core';
import {bootstrap}    from '@angular/platform-browser-dynamic'
import {AppServiceGamer} from './services/app.service.gamer';
import {HTTP_PROVIDERS} from '@angular/http';
import {GamerComponent} from './components/gamer/gamer.component';

//enableProdMode();
bootstrap(GamerComponent, [HTTP_PROVIDERS, AppServiceGamer]); 