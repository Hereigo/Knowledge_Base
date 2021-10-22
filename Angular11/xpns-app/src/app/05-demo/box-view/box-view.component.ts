import { Component, Input, OnInit } from '@angular/core';
import { GlobalService } from '../Services/global.service';
import { LocalService } from '../Services/local.service';

@Component({
  selector: 'app-box-view',
  templateUrl: './box-view.component.html',
  styleUrls: ['./box-view.component.css'],
  providers: [LocalService] // Local!
})
export class BoxViewComponent implements OnInit {

  constructor(
    private localService: LocalService,
    private globalService: GlobalService,
  ) { }

  @Input()
  boxItem = {
    name: 'boxItem',
    quantity: 0,
  }

  ngOnInit() {
    // To bind service with current data value.
    this.localService.localServiceNumber = this.boxItem.quantity;
  }

  incrementByLocalSvc() {
    this.boxItem.quantity = this.localService.localSvcIncrement();
    // To FIX lags with Summary Update!
    this.globalService.countUp();
  }

}