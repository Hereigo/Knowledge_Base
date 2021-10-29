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

import { AaaSvcComponent } from './04-services/aaa-service/aaa-svc.component';
import { AaaSvcService } from './04-services/Services/aaa-svc.service';
import { LocalSvcComponent } from './04-services/local-svc/local-svc.component';
import { MySvcComponent } from './04-services/my-svc.component';
import { DemoComponent } from './05-demo/demo-boxes.component';
import { BoxViewComponent } from './05-demo/box-view/box-view.component';
import { RxJSComponent } from './06-rx-js/rx-js.component';
import { IntervalComponent } from './06-rx-js/interval/interval.component';
import { OperatorsComponent } from './06-rx-js/operators/operators.component';
import { HttpClientComponent } from './07-http-client/http-client.component';
import { HttpReq1Component } from './07-http-client/http-req1/http-req1.component';
import { HttpClientModule } from '@angular/common/http';
import { HttpReq2Component } from './07-http-client/http-req2/http-req2.component';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { BackendSvcService } from './07-http-client/http-req2/services/backend-svc.service';

@NgModule({
  declarations: [
    AppComponent,
    ChildComponent,
    DataChildComponent,
    DataPassComponent,
    DataSubChildComponent,
    StylesInheritanceComponent,
    AaaSvcComponent,
    LocalSvcComponent,
    MySvcComponent,
    DemoComponent,
    BoxViewComponent,
    RxJSComponent,
    IntervalComponent,
    OperatorsComponent,
    HttpClientComponent,
    HttpReq1Component,
    HttpReq2Component,
  ],
  imports: [
    AppRoutingModule,
    BindsRoutesModule,
    BrowserModule,
    HttpClientModule,
    // npm install --save angular-in-memory-web-api (is necessary for InMemoryWebApiModule).
    InMemoryWebApiModule.forRoot(BackendSvcService, { delay: 700 }),
    // To use "GetDataService" - Comment the line above.
  ],
  providers: [
    AaaSvcService, // - also CAN be registered in SERVICE
    // OR Registered in a COMPONENT if use LOCALLY.
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
