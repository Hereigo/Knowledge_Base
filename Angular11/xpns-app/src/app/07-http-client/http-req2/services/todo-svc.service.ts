import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TodoSvcService {

  constructor(private http: HttpClient) { }

  getItems() {
    return this.http.get('api/todos');
  }

  addItems(task: any) {
    return this.http.post('api/todos', { name: task });
  }

  editItems(task: { id: any; }) {
    return this.http.put(`api/todos/${task.id}`, task);
  }

  deleteItem(id: any) {
    return this.http.delete(`api/todos/${id}`);
  }

}
