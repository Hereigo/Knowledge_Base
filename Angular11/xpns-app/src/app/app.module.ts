import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { BindsRoutesModule } from './01-binds-routes/binds-routes.module';
import { StylesInheritanceComponent } from './02-styles-inheritance/styles-inheritance.component';
import { ChildComponent } from './02-styles-inheritance/child/child.component';

@NgModule({
  declarations: [
    AppComponent,
    StylesInheritanceComponent,
    ChildComponent
  ],
  imports: [
    AppRoutingModule,
    BindsRoutesModule,
    BrowserModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
