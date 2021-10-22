import { Injectable } from '@angular/core';

@Injectable()
export class LocalService {

  localServiceNumber: number = 0;

  localSvcIncrement() {
    return ++this.localServiceNumber;
  }

}
