import { Component, OnInit } from '@angular/core';
import { ServerDataService } from '../services/server-data.service';

@Component({
  selector: 'app-operators',
  templateUrl: './operators.component.html',
  styleUrls: ['./operators.component.css']
})
export class OperatorsComponent implements OnInit {

  list: any;

  constructor(private dbService: ServerDataService) { }

  ngOnInit(): void {
    this.dbService.getData().subscribe(data => this.list = data);
  }

}
