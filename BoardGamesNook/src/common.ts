import { Location } from '@angular/common';

export class Common  {
    constructor(
        private location?: Location
    ) { }

    goBack(): void {
        this.location.back();
    }

    showErrorOrGoBack(errorMessage): void {
        debugger;
        if (errorMessage !== "") {
            alert(errorMessage);
            return;
        } else {
            return this.goBack();
        }
    }

    handleError(error: any, message?: any): Promise<string> {
        let errorDetails: string = error.message != "" ? error.message : "";
        if (error.message !== "") {
            message = error + errorDetails;
        }
        else if (error.name !== "Error") {
            message = error.name;
        }
        else {
            message = "Wystąpił nieznany błąd";
        }

        return message;
    }
}