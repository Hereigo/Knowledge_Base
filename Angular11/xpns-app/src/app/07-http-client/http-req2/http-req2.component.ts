import { Component, OnInit } from '@angular/core';
import { TodoSvcService } from './services/todo-svc.service';

@Component({
  selector: 'app-http-req2',
  templateUrl: './http-req2.component.html',
  styleUrls: ['./http-req2.component.css']
})
export class HttpReq2Component implements OnInit {

  todoList: any;
  editingTasks: any;

  constructor(private todoSvc: TodoSvcService) { }

  ngOnInit(): void {
    this.getTodoTasks();
  }

  getTodoTasks(): any {
    this.todoSvc.getItems().subscribe(todos => {
      console.log(todos);
      this.todoList = todos;
    });
  }

  addTodo(newTodoText: string) {
    this.todoSvc.addItems(newTodoText).subscribe(result => {
      console.log(result);
      this.todoList.push(result);
      // this.getTodoTasks();
    })
  }

  editStart(task: any, input: any) {
    this.editingTasks = task;
    input.value = task.name;
  }

  editFinish(newText: string) {
    this.editingTasks.name = newText;
    this.todoSvc.editItems(this.editingTasks).subscribe(result => {
      console.log(result);
      // Removing the Reference to our Task.
      this.editingTasks = null;
    });
  }

  deleteTask(id: number) {
    this.todoSvc.deleteItem(id).subscribe(result => {
      console.log(result);
      this.getTodoTasks();
    });
  }

}
