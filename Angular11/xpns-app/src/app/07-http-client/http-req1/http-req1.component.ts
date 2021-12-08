import { Component, OnInit } from '@angular/core';
import { GetDataService } from './services/get-data.service';

@Component({
  selector: 'app-http-req1',
  templateUrl: './http-req1.component.html',
  styleUrls: []
})
export class HttpReq1Component implements OnInit {

  users: any;

  // Service injection:
  constructor(private dataService: GetDataService) { }

  ngOnInit(): void {
    // Subscribe to Observable response of Service.
    this.dataService.getDataFromService().subscribe(res => {
      console.log(res);
      this.users = res;
    });
  }

}
