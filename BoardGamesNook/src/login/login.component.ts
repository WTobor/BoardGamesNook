import { Component } from '@angular/core';
import {UserGamer} from "../userGamer/userGamer";

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})

export class LoginComponent {
    model = new UserGamer();
    submitted = false;
    onSubmit() { this.submitted = true; }
    newUser() {
        this.model = new UserGamer();
    }
}