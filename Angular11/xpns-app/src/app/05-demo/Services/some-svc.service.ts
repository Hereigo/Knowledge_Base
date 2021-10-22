import { Injectable } from '@angular/core';

@Injectable()
export class SomeSvcService {

  svcBoxesStorage: { name: string, quantity: number }[] = [];

  svcIncrement(boxName: string) {
    let result = this.svcBoxesStorage.find(b => b.name === boxName);
    result!.quantity++; // = result!.quantity+1;
  }

  // Called by ngAfterViewChecked() of Component.
  countUp() {
    let sum = 0;
    this.svcBoxesStorage.forEach(bx => sum += bx.quantity)
    return sum;
  }

}
