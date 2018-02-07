import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { User } from "./user";
import { Observable } from "rxjs/Observable";

@Injectable()
export class UserService {
    private getUserUrl = "User/Get";
    private logOutUserUrl = "User/LogOut";

    constructor(private http: HttpClient, private router: Router) {}

    getUser(): Observable<User> {
        const url = `${this.getUserUrl}`;
        return this.http.get<User>(url);
    }

    logOutUser(): void {
        const url = `${this.logOutUserUrl}`;
        this.http.get(url);
    }
}