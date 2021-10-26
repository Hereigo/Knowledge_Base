import { Component, OnInit } from '@angular/core';
import { ServerDataService } from '../services/server-data.service';

@Component({
  selector: 'app-operators',
  templateUrl: './operators.component.html',
  styleUrls: ['./operators.component.css']
})
export class OperatorsComponent implements OnInit {

  list: any; // string[];

  constructor(private dbService: ServerDataService) { }

  ngOnInit(): void {
    // this.list = this.dbService.getData();
    this.dbService.getData().subscribe(data => this.list = data);
  }

}
