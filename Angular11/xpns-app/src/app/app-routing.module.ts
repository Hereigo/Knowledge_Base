import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BindsRoutesComponent } from './01-binds-routes/binds-routes.component';
import { CccComponent } from './ccc/ccc.component';

const routes: Routes = [
  { path: '', component: BindsRoutesComponent },
  { path: 'ccc', component: CccComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
