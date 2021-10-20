import { AppRoutingModule } from './app-routing.module';
import { BindsRoutesModule } from './01-binds-routes/binds-routes.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { ChildComponent } from './02-styles-inheritance/child/child.component';
import { StylesInheritanceComponent } from './02-styles-inheritance/styles-inheritance.component';

import { DataChildComponent } from './03-data-pass/data-child/data-child.component';
import { DataPassComponent } from './03-data-pass/data-pass.component';
import { DataSubChildComponent } from './03-data-pass/data-child/data-sub-child/data-sub-child.component';


import { MyServicesComponent } from './04-my-services/my-services.component';
import { MyServicesService } from './04-my-services/my-services.service';

@NgModule({
  declarations: [
    AppComponent,
    ChildComponent,
    DataChildComponent,
    DataPassComponent,
    DataSubChildComponent,
    StylesInheritanceComponent,
    MyServicesComponent,
  ],
  imports: [
    AppRoutingModule,
    BindsRoutesModule,
    BrowserModule,
  ],
  providers: [
    MyServicesService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
