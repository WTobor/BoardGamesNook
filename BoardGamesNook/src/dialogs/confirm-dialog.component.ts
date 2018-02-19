import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material";

@Component({
    selector: "confirm-dialog",
    template: `
        <p>{{ title }}</p>
        <p>{{ message }}</p>
        <button type="button" md-raised-button 
            (click)="dialogRef.close(true)">OK</button>
        <button type="button" md-button 
            (click)="dialogRef.close()">Cancel</button>
    `,
})
export class ConfirmDialogComponent {

    title: string;
    message: string;

    constructor(public dialogRef: MatDialogRef<ConfirmDialogComponent>) {

    }
}