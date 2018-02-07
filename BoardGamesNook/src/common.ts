import { Location } from "@angular/common";
import { Router } from "@angular/router";
import {HttpHeaders} from "@angular/common/http/src/headers";

export const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

export class Common {
    constructor(
        private location?: Location,
        private router?: Router
    ) {
    }

    goBack(): void {
        this.location.back();
    }
    
    showErrorOrGoBack(errorMessage): void {
        if (errorMessage !== "") {
            alert(errorMessage);
            return;
        } else {
            return this.goBack();
        }
    }

    showErrorOrReturn(errorMessage): void {
        if (errorMessage !== "") {
            alert(errorMessage);
        }
        return;
    }
}