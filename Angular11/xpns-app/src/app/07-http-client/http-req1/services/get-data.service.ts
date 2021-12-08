import { Injectable } from '@angular/core';
// In Module registration REQUIRED !!!
// @NgModule({ imports: [ HttpClientModule, ... ] from '@angular/common/http';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GetDataService {

  constructor(private http: HttpClient) { }

  // Comment in AppModule the FAKE-svc Module as a line below to let THIS srv work!!!
  // InMemoryWebApiModule.forRoot(BackendSvcService, { delay: 700 }),

  getDataFromService() {
    // returns Observable object (to wait for response).
    return this.http.get('https://jsonplaceholder.typicode.com/users');
    // Json parsed automatically!
  }
}
