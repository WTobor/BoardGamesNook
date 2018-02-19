import { Location } from "@angular/common";
import { Router } from "@angular/router";
import { HttpHeaders } from "@angular/common/http";
import {DialogsService} from "./dialogs/confirm-dialog.service";

export const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': "application/json"
    })
};

export class Common {
    constructor(
        private location?: Location,
        private dialogsService?: DialogsService,
        private router?: Router
    ) {
    }

    goBack(): void {
        this.location.back();
    }

    showAlert(errorMessage: string): void {
        this.dialogsService.confirm("Error", errorMessage);
    }

    showErrorOrGoBack(errorMessage: string): void {
        if (errorMessage !== "") {
            return this.showAlert(errorMessage);
        } else {
            return this.goBack();
        }
    }

    showErrorOrReturn(errorMessage: string): void {
        if (errorMessage !== "") {
            return this.showAlert(errorMessage);
        }
        return;
    }
}