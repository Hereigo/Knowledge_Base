import { Component, ViewChild } from '@angular/core';
import { DataChildComponent } from './data-child/data-child.component';

@Component({
  selector: 'app-data-pass',
  templateUrl: './data-pass.component.html',
  styleUrls: ['./data-pass.component.css']
})
export class DataPassComponent {

  // Find FIRST! 'DataChildComponent'-block :
  @ViewChild(DataChildComponent) child1: DataChildComponent = new DataChildComponent;
  switchBg1() {
    this.child1.childsSwitchBg();
  }

  // Find FIRST! 'DataChildComponent' by #selectedChildFIRST tag :
  @ViewChild('selectedChildFIRST') child2: DataChildComponent = new DataChildComponent;
  switchBg2() {
    this.child2.childsSwitchBg();
  }

}
