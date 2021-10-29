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

  editItems(changedTask: { id: any; }) {
    return this.http.put(`api/todos/${changedTask.id}`, changedTask);
  }

  deleteItem(id: number) {
    return this.http.delete(`api/todos/${id}`);
  }

}
