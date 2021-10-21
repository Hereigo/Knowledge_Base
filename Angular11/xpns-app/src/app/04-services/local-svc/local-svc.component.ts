import { Component, OnInit } from '@angular/core';
import { LocalSvcService } from './local-svc.service';

@Component({
  selector: 'app-local-svc',
  templateUrl: './local-svc.component.html',
  styleUrls: ['./local-svc.component.css'],
  providers: [LocalSvcService] // Local Svc registered IN COMPONENT!
})
export class LocalSvcComponent implements OnInit {

  listItems: string[] | undefined;

  constructor(private localSvc: LocalSvcService) { }

  ngOnInit() {
    this.listItems = this.localSvc.GetListItems();
  }

}