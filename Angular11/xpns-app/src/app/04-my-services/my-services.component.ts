import { Component } from '@angular/core';
import { MyServicesService } from './my-services.service';

@Component({
  selector: 'app-my-services',
  templateUrl: './my-services.component.html',
  styleUrls: ['./my-services.component.css']
})
export class MyServicesComponent {

  // Inject Service in Ctor.
  constructor(private mySvc: MyServicesService) { }

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
