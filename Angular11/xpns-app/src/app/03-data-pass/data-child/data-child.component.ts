import { Component, ContentChild, ContentChildren, ElementRef, QueryList } from '@angular/core';
import { DataSubChildComponent } from './data-sub-child/data-sub-child.component';

@Component({
  selector: 'app-data-child',
  templateUrl: './data-child.component.html',
  styleUrls: ['./data-child.component.css']
})
export class DataChildComponent {

  @ContentChild('insideAppChildTag') childComponentRef!: ElementRef;
  // @ContentChild(DataSubChildComponent) subChild!: DataSubChildComponent;
  @ContentChildren(DataSubChildComponent) subChildren!: QueryList<DataSubChildComponent>;

  changeMyColor() {
    if (this.childComponentRef) {
      var color = this.childComponentRef.nativeElement.style.color;
      this.childComponentRef.nativeElement.style.color = color == 'red' ? 'black' : 'red';
    }
    // if (this.subChild) {
    //   this.subChild.subChildMethod();
    // }
    if (this.subChildren) {
      this.subChildren.forEach(c => c.subChildMethod());
    }
  }

  isBgActive = false;

  childSwitchMethod() {
    this.isBgActive = !this.isBgActive;
  }

}
