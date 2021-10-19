import { Component, ContentChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-data-child',
  templateUrl: './data-child.component.html',
  styleUrls: ['./data-child.component.css']
})
export class DataChildComponent {

  @ContentChild('strInsideAppChildTag') childComponentRef!: ElementRef;

  changeMyColor() {
    if (this.childComponentRef) {
      var color = this.childComponentRef.nativeElement.style.color;
      this.childComponentRef.nativeElement.style.color = color == 'black' ? 'red' : 'black';
    }
  }

  isBgActive = false;

  childSwitchMethod() {
    this.isBgActive = !this.isBgActive;
  }

}
