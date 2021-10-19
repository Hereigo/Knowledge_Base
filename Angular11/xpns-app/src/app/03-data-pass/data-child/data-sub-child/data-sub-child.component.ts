import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-data-sub-child',
  templateUrl: './data-sub-child.component.html',
  styleUrls: ['./data-sub-child.component.css']
})
export class DataSubChildComponent {

  subChildBG: string = "lightcyan";

  subChildMethod() {
    this.subChildBG = this.subChildBG == "lightcyan" ? "yellow" : "lightcyan";
  }

}
