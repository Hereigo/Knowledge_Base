import { Injectable } from '@angular/core';

import { delay } from 'rxjs/internal/operators';
import { map } from 'rxjs/operators';
import { of } from 'rxjs'; // Works with Streams to handle changes.

@Injectable({
  providedIn: 'root'
})
export class ServerDataService {

  constructor() { }

  getData() {
    // syncronous work.
    let data = [];
    for (let i = 0; i < 6; i++) {
      ++i;
      data.push('A-' + i + i + i);
    };
    // asyncronous work.
    return of(data) // Stream created here.
      .pipe(
        delay(3000),
        map(text => {
          console.log("\r\n Method map() works in the ServerDataService before return Collection.");
          return text.concat("This item added in the Service - (see console).")
        }),
        delay(3000)
      );
  }
}
