import { Component, OnInit } from "@angular/core";
import { UserService } from "./users/user.service";
import { User } from "./users/user";
import { Gamer } from "./gamers/gamer";

@Component({
    selector: "my-app",
    templateUrl: "./src/app.component.html"
})
export class AppComponent implements OnInit {
    user: User;
    gamer: Gamer;

    constructor(
        private userService: UserService
    ) { }

    ngOnInit() {
        this.userService.getUser().then((user: User) => { this.user = user });
    }

    logOut(): void {
        this.userService.logOutUser();
    }
}