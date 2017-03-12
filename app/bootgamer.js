"use strict";
var platform_browser_dynamic_1 = require('@angular/platform-browser-dynamic');
var app_service_gamer_1 = require('./services/app.service.gamer');
var http_1 = require('@angular/http');
var gamer_component_1 = require('./components/gamer/gamer.component');
//enableProdMode();
platform_browser_dynamic_1.bootstrap(gamer_component_1.GamerComponent, [http_1.HTTP_PROVIDERS, app_service_gamer_1.AppServiceGamer]);
//# sourceMappingURL=bootgamer.js.map