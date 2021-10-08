import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AaaComponent } from './aaa/aaa.component';
import { BbbComponent } from './bbb/bbb.component';
import { CccComponent } from './ccc/ccc.component';

const routes: Routes = [
  { path: '', component: AaaComponent },
  { path: 'bbb', component: BbbComponent },
  { path: 'ccc', component: CccComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
