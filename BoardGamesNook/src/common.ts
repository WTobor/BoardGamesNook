import { Location } from "@angular/common";
import { Router } from "@angular/router";

export class Common  {
    constructor(
        private location?: Location,
        private router?: Router
    ) { }

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

    handleError(error: any, message?: any): Promise<string> {
        let errorDetails: string = error.message !== "" ? error.message : "";
        if (error !== "Error") {
            message += error;
        }
        else if (typeof error.message !== "undefined" && error.message !== "") {
            message += errorDetails;
        }
        else {
            message = "Wystąpił nieznany błąd";
        }

        return message;
    }
}