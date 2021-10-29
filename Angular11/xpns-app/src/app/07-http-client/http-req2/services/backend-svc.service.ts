import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';

// To use FAKE backend :
// npm install --save angular-in-memory-web-api
// Add into @NgModule({ imports: [ 
// ............., InMemoryWebApiModule.forRoot(BackendSvcService, { delay:700 }),
// Fake-Backend will be at - /api/todos

@Injectable({
  providedIn: 'root'
})
export class BackendSvcService implements InMemoryDbService {

  constructor() { }

  createDb() {
    let todos = [
      { id: 1, name: "Task 1" },
      { id: 2, name: "Task 2" },
      { id: 3, name: "Task 3" },
      { id: 4, name: "Task 4" }
    ];

    // return { todos: todos };
    return { todos };
  }
}
