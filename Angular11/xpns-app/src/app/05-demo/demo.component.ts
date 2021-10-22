import { Component, OnInit, AfterViewChecked, ChangeDetectorRef } from '@angular/core';
import { SomeSvcService } from './Services/some-svc.service';

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
  templateUrl: './demo.component.html',
  styleUrls: ['./demo.component.css'],
  providers: [SomeSvcService]
})
export class DemoComponent implements OnInit, AfterViewChecked {

  totalSum: number = 0;
  boxes = boxesArray;

  constructor(
    private service: SomeSvcService,
    private chngDetectRef: ChangeDetectorRef // For ngAfterViewChecked()
  ) { }

  incrementByName(boxName: string) {
    this.service.svcIncrement(boxName);
  }

  ngOnInit(): void {
    // Bind to Service data for process by Service.
    this.service.svcBoxesStorage = this.boxes;
  }

  ngAfterViewChecked(): void {
    this.totalSum = this.service.countUp();
    // To prevent - Expression has changed after it was checked error.
    this.chngDetectRef.detectChanges();
  }
}