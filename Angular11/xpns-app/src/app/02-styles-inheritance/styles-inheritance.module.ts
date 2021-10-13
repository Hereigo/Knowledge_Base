import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StylesInheritanceComponent } from './styles-inheritance.component';
import { ChildComponent } from './child/child.component';

@NgModule({
  declarations: [
    StylesInheritanceComponent,
    ChildComponent
  ],
  imports: [
    CommonModule
  ]
})
export class StylesInheritanceModule { }
