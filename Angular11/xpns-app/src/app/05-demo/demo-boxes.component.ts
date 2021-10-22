import { Component, OnInit, AfterViewChecked, ChangeDetectorRef } from '@angular/core';
import { GlobalService } from './Services/global.service';

const boxesArray = [
  {
    name: 'Box A1',
    quantity: 13,
  }, {
    name: 'Box B2',
    quantity: 20,
  }
];

@Component({
  selector: 'app-demo',
  templateUrl: './demo-boxes.component.html',
  styleUrls: ['./demo-boxes.component.css'],
})
export class DemoComponent implements OnInit, AfterViewChecked {

  totalSum: number = 0;
  boxes = boxesArray;

  constructor(
    private globalService: GlobalService,
    private chngDetectRef: ChangeDetectorRef // For ngAfterViewChecked()
  ) { }

  incrementByName(boxName: string) {
    this.globalService.svcIncrement(boxName);
  }

  ngOnInit(): void {
    // Bind to Service data for process by Service.
    this.globalService.svcBoxesStorage = this.boxes;
  }

  ngAfterViewChecked(): void {
    this.totalSum = this.globalService.countUp();
    // To prevent - Expression has changed after it was checked error.
    this.chngDetectRef.detectChanges();
  }

}