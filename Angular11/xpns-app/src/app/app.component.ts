import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor() {
    this.startInterval();
  }

  counter: number = 0;
  isChecked = true;
  isCounterOn = true;

  startInterval() {
    setInterval(() => {
      if (this.isCounterOn) {
        this.counter++;
        if (this.counter % 2 == 0) this.isChecked = true;
        else this.isChecked = false;
      }
    }, 1000);
  }

  switchCounter() {
    this.isCounterOn = !this.isCounterOn;
  }

}
