import { Component } from '@angular/core';
import { AaaSvcService } from './aaa-svc.service';

@Component({
  selector: 'app-aaa-service',
  templateUrl: './aaa-svc.component.html',
  styleUrls: ['./aaa-svc.component.css']
})
export class AaaSvcComponent {

  // Inject Service in Ctor.
  constructor(private mySvc: AaaSvcService) { }

  componentCounter: number = 0;

  plus() {
    this.mySvc.svcIncrement();
    this.componentCounter = this.mySvc.serviceCounter;
  }

  minus() {
    this.mySvc.svcDecrement();
    this.componentCounter = this.mySvc.serviceCounter;
  }

}
