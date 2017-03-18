import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//import { PageNotFoundComponent } from './not-found.component';

import { AuthGuard } from './auth-guard.service';

const appRoutes: Routes = [
    {
        path: 'admin',
        loadChildren: 'app/admin/admin.module#AdminModule',
        canLoad: [AuthGuard]
    }
    //{ path: '', redirectTo: '/', pathMatch: 'full' },
    //{ path: '**', component: PageNotFoundComponent }
];

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes
        )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }