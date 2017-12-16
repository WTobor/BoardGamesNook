import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { WelcomeComponent } from "./welcome.component";

const welcomeRoutes: Routes = [
    { path: "_", component: WelcomeComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(welcomeRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class WelcomeRoutingModule {
}