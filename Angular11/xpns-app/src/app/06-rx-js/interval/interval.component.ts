import { Component, OnDestroy, OnInit } from '@angular/core';
import { interval } from 'rxjs';

@Component({
  selector: 'app-interval',
  templateUrl: './interval.component.html',
  styleUrls: ['./interval.component.css']
})
export class IntervalComponent implements OnDestroy {

  threeSecondsInterval;

  constructor() {

    interval(500)

    interval(1000).subscribe((value) => {
      console.log("ONE second", value);
    });

    this.threeSecondsInterval = interval(3000);
  }

  goInterval() {
    this.threeSecondsInterval.subscribe((value) => {
      console.log("THREE second", value);
    });
  }

  ngOnDestroy() {

  }

}