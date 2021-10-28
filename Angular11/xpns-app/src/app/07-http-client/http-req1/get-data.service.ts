import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GetDataService {

  // In Module registration REQUIRED !!!
  // @NgModule({ imports: [ HttpClientModule, ... ] from '@angular/common/http';
  constructor(private http: HttpClient) { }

  getDataFromService() {
    // Json parsed automatically!
    return this.http.get('https://jsonplaceholder.typicode.com/users');
  }
}
