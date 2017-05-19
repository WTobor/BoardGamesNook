import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { LoginComponent } from "./login.component";
import { RegisterComponent } from "./register.component";

const accountRoutes: Routes = [
    { path: "login", component: LoginComponent },
    { path: "register", component: RegisterComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(accountRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class AccountRoutingModule { }