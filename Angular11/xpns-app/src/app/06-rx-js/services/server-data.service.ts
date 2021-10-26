import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators'
import { delay } from 'rxjs/internal/operators'

@Injectable({
  providedIn: 'root'
})
export class ServerDataService {

  constructor() { }

  getData() {
    let data = [];
    for (let i = 0; i < 6; i++) {
      ++i;
      data.push('A-' + i + i + i);
    }
    return of(data).pipe(
      delay(1000),
      map(text => {
        console.log("Method map() works.");
        return text.concat("new content ")
      }),
      delay(1000)
    );
  }
}
