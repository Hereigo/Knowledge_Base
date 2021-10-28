import { Injectable } from '@angular/core';

import { delay } from 'rxjs/internal/operators';
import { map } from 'rxjs/operators';
import { of } from 'rxjs'; // Works with Streams to handle changes.

@Injectable({
  providedIn: 'root'
})
export class ServerDataService {

  constructor() { }

  // syncronous work.
  getData() {
    let data = [];
    for (let i = 0; i < 6; i++) {
      ++i;
      data.push('A-' + i + i + i);
    }
    // asyncronous work.
    return of(data) // Stream created.
      .pipe(
        delay(2000),
        map(text => {
          console.log("Method map() works.");
          return text.concat("new content ")
        }),
        delay(2000)
      );
  }
}
