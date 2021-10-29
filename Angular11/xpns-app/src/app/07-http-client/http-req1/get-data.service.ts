import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GetDataService {

  // In Module registration REQUIRED !!!
  // @NgModule({ imports: [ HttpClientModule, ... ] from '@angular/common/http';
  constructor(private http: HttpClient) { }
  
  // Comment in the AppModule the line as below one to WORK THIS SERVICE !!!
  // InMemoryWebApiModule.forRoot(BackendSvcService, { delay: 700 }),

  getDataFromService() {
    // Json parsed automatically!
    return this.http.get('https://jsonplaceholder.typicode.com/users');
  }
}
