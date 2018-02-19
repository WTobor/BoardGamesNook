import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatButtonModule, MatDialogModule } from "@angular/material";
import {DialogsService} from "./confirm-dialog.service";
import {ConfirmDialogComponent} from "./confirm-dialog.component";

@NgModule({
    imports: [
        CommonModule,
        MatDialogModule,
        MatButtonModule,
    ],
    declarations: [ConfirmDialogComponent],
    exports: [ConfirmDialogComponent],
    entryComponents: [ConfirmDialogComponent],
    providers: [DialogsService]
})
export class DialogsModule {
}