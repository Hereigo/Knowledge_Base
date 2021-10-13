import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent {

  @Input()
  childProperty = 0;

  @Output()
  parentEvent: EventEmitter<string> = new EventEmitter();

  textInput = '';

  textType(inputed: string) {
    this.textInput = inputed;
    this.parentEvent.emit(this.textInput);
  }

}
