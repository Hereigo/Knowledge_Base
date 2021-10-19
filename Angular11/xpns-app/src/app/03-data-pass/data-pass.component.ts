import { Component, ElementRef, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { DataChildComponent } from './data-child/data-child.component';

@Component({
  selector: 'app-data-pass',
  templateUrl: './data-pass.component.html',
  styleUrls: ['./data-pass.component.css']
})
export class DataPassComponent {

  text: string = "Inside App-Child Tag Data for Child's <NG-CONTENT>.";

  // Find FIRST! 'DataChildComponent'-block :
  @ViewChild(DataChildComponent) firstDCComponent = new DataChildComponent;
  // OR
  @ViewChild('taggedChild') firstTaggedDCComp = new DataChildComponent;
  
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
