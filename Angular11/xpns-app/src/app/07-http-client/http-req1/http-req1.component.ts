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
    // Subscribe to Observable object of Service's response.
    this.dataService.getDataFromService().subscribe(resp => {
      console.log(resp);
      this.users = resp;
    });
  }

}
