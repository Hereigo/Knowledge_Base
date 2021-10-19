import { Component, ElementRef, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { Data } from '@angular/router';
import { DataChildComponent } from './data-child/data-child.component';

@Component({
  selector: 'app-data-pass',
  templateUrl: './data-pass.component.html',
  styleUrls: ['./data-pass.component.css']
})
export class DataPassComponent {

  // Find FIRST! 'DataChildComponent'-block :
  @ViewChild(DataChildComponent) firstDCComponent: DataChildComponent = new DataChildComponent;
  // OR
  // Find FIRST! 'DataChildComponent' by #taggedChild tag :
  @ViewChild('taggedChild') firstTaggedDCComp: DataChildComponent = new DataChildComponent;

  switchFirstChild() {
    this.firstTaggedDCComp.childSwitchMethod();
  }

  @ViewChild('inputForElementRef')
  textInputRef !: ElementRef;

  takeFocus() {
    this.textInputRef.nativeElement.focus();
  }

  @ViewChildren('taggedChild') children!: QueryList<any>;

  switchAllTaggedChildren() {
    this.children.forEach(ch => ch.childSwitchMethod());
  }

}
