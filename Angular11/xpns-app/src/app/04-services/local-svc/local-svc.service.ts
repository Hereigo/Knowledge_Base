import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalSvcService {

  GetListItems(){
    return ['aaa','bbb','ccc','ddd'];
  }
}
