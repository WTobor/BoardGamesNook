import { Observable } from "rxjs/Rx";
import { MatDialog } from "@angular/material";
import { Injectable } from "@angular/core";
import { ConfirmDialogComponent} from "./confirm-dialog.component";

@Injectable()
export class DialogsService {

    constructor(private dialog: MatDialog) {}

    confirm(title: string, message: string): Observable<boolean> {

        const dialogRef = this.dialog.open(ConfirmDialogComponent);
        dialogRef.componentInstance.title = title;
        dialogRef.componentInstance.message = message;

        return dialogRef.afterClosed();
    }
}