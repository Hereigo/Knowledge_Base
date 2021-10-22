import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-box-view',
  templateUrl: './box-view.component.html',
  styleUrls: ['./box-view.component.css']
})
export class BoxViewComponent {

  @Input()
  boxItem = {
    name: 'boxItem',
    quantity: 0,
  }

  boxName: string = 'boxName';

  boxQuantity: number = 0;

}