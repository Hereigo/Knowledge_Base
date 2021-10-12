import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-binds-routes',
  templateUrl: './binds-routes.component.html',
  styleUrls: ['./binds-routes.component.css']
})
export class BindsRoutesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void { }

  aaaProperty = 'Component-Property';
  linesList = ['11111', '22222', '33333'];
  myTextSpanValue = ' - Type and press Enter.';
  switchChoice = 1;
  toggle = true;

  addToList(): void {
    this.linesList.push('abcde');
  }

  grabTextInput(text: { toString: () => any; }) {
    this.myTextSpanValue = ' - ' + text.toString();
  }

  switchCase(): void {
    if (this.switchChoice > 3) {
      this.switchChoice = 1;
    } else {
      this.switchChoice++;
    }
  }

}
