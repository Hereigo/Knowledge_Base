import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AaaSvcService {

  serviceCounter: number = 0;

  svcIncrement() {
    this.serviceCounter++;
  }

  svcDecrement() {
    this.serviceCounter--;
  }

}
