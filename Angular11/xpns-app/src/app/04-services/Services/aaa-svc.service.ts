import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root' // Means Service Globally registered (as in AppModule).
  // OR 
  // providedIn: SomeAnotherModule
})
export class AaaSvcService {

  serviceCounter: number = 0;

  svcIncrement() {
    this.serviceCounter++;
  }

  svcDecrement() {
    this.serviceCounter--;
  }

  GetListItems() {
    let data = [];
    for (let i = 1; i < 4; i++) {
      data.push('Item - ' + i + i + i);
    }
    return data;
  }

}
