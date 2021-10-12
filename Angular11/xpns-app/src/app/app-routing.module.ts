import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BindsRoutesComponent } from './01-binds-routes/binds-routes.component';
import { StylesInheritanceComponent } from './02-styles-inheritance/styles-inheritance.component';

const routes: Routes = [
  { path: '', component: BindsRoutesComponent },
  { path: 'styles', component: StylesInheritanceComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
