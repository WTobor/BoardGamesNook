import { Component } from '@angular/core';
import { MdDialog, MdDialogRef } from "@angular/material";

@Component({
    selector: 'popup',
    templateUrl: './src/popup/popup.component.html',
    styleUrls: ['./src/popup/popup.component.css'],
})
export class PopupComponent {
    constructor(
        public dialogRef: MdDialogRef<PopupComponent>) {
    }
}