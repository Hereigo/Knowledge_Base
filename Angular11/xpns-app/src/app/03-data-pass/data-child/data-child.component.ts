import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-data-child',
  templateUrl: './data-child.component.html',
  styleUrls: ['./data-child.component.css']
})
export class DataChildComponent {

  isBgActive = false;

  childSwitchMethod() {
    this.isBgActive = !this.isBgActive;
  }

}
