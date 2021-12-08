import { Component, OnDestroy } from '@angular/core';
import { interval, Subscription } from 'rxjs';

@Component({
  selector: 'app-interval',
  templateUrl: './interval.component.html',
  styleUrls: ['./interval.component.css']
})
export class IntervalComponent implements OnDestroy {

  oneSecObservableObject;
  threeSecObservableObject: Subscription | undefined;

  constructor() {
    this.oneSecObservableObject = interval(1000).subscribe((value) => {
      console.log("ONE second", value);
    });
  }

  toggleAnotherInterval() {
    this.threeSecObservableObject = interval(3000).subscribe((value) => {
      console.log("+ THREE seconds", value);
    });
  }

  ngOnDestroy() {
    this.oneSecObservableObject.unsubscribe();
    
    // Unsubscribed ONLY FIRST created subscription!!!
    if (this.threeSecObservableObject)
      this.threeSecObservableObject.unsubscribe();
  }

}