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

  ngOnInit(): void { }

  aaaProperty = 'Component-Property';
  counter: number = 0;
  isChecked = true;
  isCounterOn = true;
  linesList = ['11111', '22222', '33333'];
  myTextSpanValue = ' - Type and press Enter.';
  switchChoice = 1;
  toggle = true;

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

  grabTextInput(text: { toString: () => any; }) {
    this.myTextSpanValue = ' - ' + text.toString();
  }

  addToList() {
    this.linesList.push('abcde');
  }

  switchCase() {
    if (this.switchChoice > 3) {
      this.switchChoice = 1;
    } else {
      this.switchChoice++;
    }
  }
}
