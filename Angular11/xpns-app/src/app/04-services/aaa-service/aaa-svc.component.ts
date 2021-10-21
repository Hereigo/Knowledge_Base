import { Component } from '@angular/core';
import { AaaSvcService } from '../Services/aaa-svc.service';

@Component({
  selector: 'app-aaa-svc',
  templateUrl: './aaa-svc.component.html',
  styleUrls: ['./aaa-svc.component.css']
})
export class AaaSvcComponent {

  componentCounter: number = 0;

  // Service Injection:
  constructor(private mySvc: AaaSvcService) { }

  plus() {
    this.mySvc.svcIncrement();
    this.componentCounter = this.mySvc.serviceCounter;
  }

  minus() {
    this.mySvc.svcDecrement();
    this.componentCounter = this.mySvc.serviceCounter;
  }

}
