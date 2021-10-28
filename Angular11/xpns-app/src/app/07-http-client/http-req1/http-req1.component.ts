import { Component, OnInit } from '@angular/core';
import { GetDataService } from './get-data.service';

@Component({
  selector: 'app-http-req1',
  templateUrl: './http-req1.component.html',
  styleUrls: []
})
export class HttpReq1Component implements OnInit {

  users: any;

  constructor(private dataService: GetDataService) { }

  ngOnInit(): void {
    this.dataService.getDataFromService().subscribe(res => {
      console.log(res);
      this.users = res;
    });
  }

}
