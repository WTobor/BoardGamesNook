import { Component, OnInit } from "@angular/core";
import { UserService } from "./users/user.service";
import { User } from "./users/user";

@Component({
    selector: "my-app",
    templateUrl: "./src/app.component.html"
})
export class AppComponent implements OnInit {
    user: User;

    constructor(
        private userService: UserService
    ) { }

    ngOnInit() {
        this.userService.getUser().then((user: User) => { debugger; this.user = user});
    }
}