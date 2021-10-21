import { Component, OnInit, AfterViewChecked, ChangeDetectorRef } from '@angular/core';
import { SomeSvcService } from './some-svc.service';

const boxesArray = [
  {
    name: 'Box A',
    quantity: 13,
  }, {
    name: 'Box B',
    quantity: 20,
  }
];

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
  styleUrls: ['./demo.component.css']
})
export class DemoComponent implements OnInit, AfterViewChecked {

  totalSum: number = 0;
  boxes = boxesArray;

  constructor(
    private someSvc: SomeSvcService,
    private chngDetectRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    
  }

  ngAfterViewChecked(): void {

  }
}
// 18-00