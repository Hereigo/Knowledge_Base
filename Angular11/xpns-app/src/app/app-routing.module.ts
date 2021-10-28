import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BindsRoutesComponent } from './01-binds-routes/binds-routes.component';
import { StylesInheritanceComponent } from './02-styles-inheritance/styles-inheritance.component';
import { DataPassComponent } from './03-data-pass/data-pass.component';
import { MySvcComponent } from './04-services/my-svc.component';
import { DemoComponent } from './05-demo/demo-boxes.component';
import { RxJSComponent } from './06-rx-js/rx-js.component';
import { HttpClientComponent } from './07-http-client/http-client.component';

const routes: Routes = [
  { path: '', component: BindsRoutesComponent },
  { path: 'styles', component: StylesInheritanceComponent },
  { path: 'data', component: DataPassComponent },
  { path: 'services', component: MySvcComponent },
  { path: 'demo', component: DemoComponent },
  { path: 'rxjs', component: RxJSComponent },
  { path: 'http', component: HttpClientComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
