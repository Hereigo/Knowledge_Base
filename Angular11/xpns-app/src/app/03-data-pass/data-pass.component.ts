import { Component, ElementRef, ViewChild } from '@angular/core';
import { DataChildComponent } from './data-child/data-child.component';

@Component({
  selector: 'app-data-pass',
  templateUrl: './data-pass.component.html',
  styleUrls: ['./data-pass.component.css']
})
export class DataPassComponent {

  // Find FIRST! 'DataChildComponent'-block :
  @ViewChild(DataChildComponent) firstDCComponent: DataChildComponent = new DataChildComponent;
  switchOne() {
    this.firstDCComponent.childsSwitchBg();
  }

  // Find FIRST! 'DataChildComponent' by #selectedChildFIRST tag :
  @ViewChild('selectedChildFIRST') firstSelectedDCComp: DataChildComponent = new DataChildComponent;
  switchTwo() {
    this.firstSelectedDCComp.childsSwitchBg();
  }

  @ViewChild('parentTextInput')
  textInputRef !: ElementRef;

  takeFocus() {
    this.textInputRef.nativeElement.focus();
  }

}
