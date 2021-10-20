import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-data-sub-child',
  templateUrl: './data-sub-child.component.html',
  styleUrls: ['./data-sub-child.component.css']
})
export class DataSubChildComponent implements OnChanges {

  @Input() // To get value from Parent.
  subChildBG!: string;

  subChildMethod() {
    this.subChildBG = this.subChildBG == "lightcyan" ? "yellow" : "lightcyan";
  }

  // To check Properties Changes:
  ngOnChanges(changes: SimpleChanges): void {
    console.log("In SUB-Child onChanges:", changes);
  }

}
