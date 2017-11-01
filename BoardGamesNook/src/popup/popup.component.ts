import { Component } from '@angular/core';
import { MatDialogRef } from "@angular/material";

@Component({
    selector: 'popup',
    templateUrl: './src/popup/popup.component.html',
    styleUrls: ['./src/popup/popup.component.css'],
})
export class PopupComponent {
    constructor(
        public dialogRef: MatDialogRef<PopupComponent>) {
    }
}