import { Component, ContentChild, ElementRef, QueryList, ViewChild, ViewChildren } from '@angular/core';
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
  @ViewChild('taggedChild') firstTaggedDCComp: DataChildComponent = new DataChildComponent;
  @ViewChild('inputForElementRef') textInputRef !: ElementRef;
  @ViewChildren('taggedChild') children!: QueryList<any>;

  switchFirstChild() {
    this.firstTaggedDCComp.childSwitchMethod();
  }
  switchAllTaggedChildren() {
    this.children.forEach(ch => ch.childSwitchMethod());
  }
  takeFocus() {
    this.textInputRef.nativeElement.focus();
  }

}
