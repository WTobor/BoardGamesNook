import { Location } from '@angular/common';

export class Common  {
    constructor(
        private location?: Location
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

    handleError(error: any, message?: any): Promise<string> {
        let errorDetails: string = error.message !== "" ? error.message : "";
        if (error !== "Error") {
            message += error;
        }
        else if (typeof error.message != "undefined" && error.message !== "") {
            message += errorDetails;
        }
        else {
            message = "Wystąpił nieznany błąd";
        }

        return message;
    }
}