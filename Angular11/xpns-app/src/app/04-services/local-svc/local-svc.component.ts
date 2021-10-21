import { Component, OnInit } from '@angular/core';
import { AaaSvcService } from '../Services/aaa-svc.service';

@Component({
  selector: 'app-local-svc',
  templateUrl: './local-svc.component.html',
  styleUrls: ['./local-svc.component.css'],
  providers: [AaaSvcService] // registered HERE it works LOCALLY!
  // in other case it must be registered in APP-MODULE (Globally).
  // OR 
  // Can be registered in SVC - @Injectable({providedIn: ... })
})
export class LocalSvcComponent implements OnInit {

  componentCounter: number = 0;

  constructor(private localSvc: AaaSvcService) { }

  plus() {
    this.localSvc.svcIncrement();
    this.componentCounter = this.localSvc.serviceCounter;
  }

  minus() {
    this.localSvc.svcDecrement();
    this.componentCounter = this.localSvc.serviceCounter;
  }

  listItems: string[] | undefined;

  ngOnInit() {
    this.listItems = this.localSvc.GetListItems();
  }
}