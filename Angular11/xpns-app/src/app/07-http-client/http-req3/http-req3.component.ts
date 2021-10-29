import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-http-req3',
  templateUrl: './http-req3.component.html',
  styleUrls: ['./http-req3.component.css']
})
export class HttpReq3Component implements OnInit {

  arr100 = Array(100);
  albums: any;
  params: any;

  constructor(private http: HttpClient) { }

  loadList(limit: number): void {
    // this.params = this.params.set('_limit', limit);
    this.http.get(
      'https://jsonplaceholder.typicode.com/albums',
      {
        params: this.params
        // same as :
        // params: params (property: variable)
      }
    ).subscribe(result => {
      console.log(result);
      this.albums = result;
    });

  }

  ngOnInit(): void {
    // --------------------------------
    // let params = new HttpParams()
    //   .set('_end', '22')
    //   .set('_start', '15');
    // --------------------------------
    // let params = new HttpParams();
    // params = params
    //   .append('_start', '15')
    //   .append('_end', '22');
    // --------------------------------
    // this.params = new HttpParams().append('_limit', '20');
    // --------------------------------
    this.params = new HttpParams();
    this.params = this.params.append('_start', '15');
    this.params = this.params.append('_end', '22');
    this.params = this.params.append('_limit', '50');
    this.params = this.params.set('_end', '33');
    this.params = this.params.delete('_limit', '50');

    // this.http.get('https://jsonplaceholder.typicode.com/albums?_start=20&_limit=10');

    this.http.get(
      'https://jsonplaceholder.typicode.com/albums',
      {
        params: this.params
        // same as :
        // params: params (property: variable)
      }
    ).subscribe(result => {
      console.log(result);
      this.albums = result;
    });

  }

  // Paused at 23:10

}
