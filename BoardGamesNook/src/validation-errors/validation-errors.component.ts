import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
    selector: 'dc-validation-errors',
    templateUrl: './src/validation-errors/validation-errors.component.html'
})
export class ValidationErrorsComponent {
    @Input()
    control: FormControl;

    private static getValidationMessage(errorCode: string) {
        switch (errorCode) {
        case 'required':
            return 'Wprowadź obowiazkową wartość';
        default:
            return 'Nieznany błąd';
        }
    }

    getErrors(): string[] {
        if (this.control && this.control.errors) {
            const messages = [];

            const errors = this.control && this.control.errors;
            if (errors) {
                for (const errorCode of Object.keys(errors)) {
                    messages.push(ValidationErrorsComponent.getValidationMessage(errorCode));
                }
            }

            return messages;
        }
    }
}
