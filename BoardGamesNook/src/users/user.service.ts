import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Router } from "@angular/router";
import "rxjs/add/operator/toPromise";
import { User } from "./user";

@Injectable()
export class UserService {
    private getUserUrl = "User/Get";
    private logOutUserUrl = "User/LogOut";

    constructor(private http: Http, private router: Router) {}

    getUser(): Promise<User> {
        const url = `${this.getUserUrl}`;
        return this.http.get(url)
            .toPromise()
            .then(response => {
                if (response.text() === "") {
                    return null;
                }
                return response.json() as User || null;
            })
            .catch(err => { return Promise.reject(err); });
    }

    logOutUser(): void {
        const url = `${this.logOutUserUrl}`;
        this.http.get(url)
            .toPromise()
            .then(() => {
                this.router.navigate(["/"]);
                window.location.reload();
            })
            .catch(err => { return Promise.reject(err); });
    }
}