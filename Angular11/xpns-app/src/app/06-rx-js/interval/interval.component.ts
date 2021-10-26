import { Component, OnDestroy, OnInit } from '@angular/core';
import { interval, Subscription } from 'rxjs';

@Component({
  selector: 'app-interval',
  templateUrl: './interval.component.html',
  styleUrls: ['./interval.component.css']
})
export class IntervalComponent implements OnDestroy {

  oneSecondsInterval;
  threeSecondsInterval: Subscription | undefined;

  constructor() {
    this.oneSecondsInterval =
      interval(1000).subscribe((value) => {
        console.log("ONE second", value);
      });
  }

  goInterval() {
    this.threeSecondsInterval= interval(3000).subscribe((value) => {
      console.log("THREE second", value);
    });
  }

  ngOnDestroy() {
    this.oneSecondsInterval.unsubscribe();
    if(this.threeSecondsInterval)
      this.threeSecondsInterval.unsubscribe();
  }

}