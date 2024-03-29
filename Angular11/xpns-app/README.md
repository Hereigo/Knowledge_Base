# Just NG XpnsApp.

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 12.2.8.

## Useful links :

> - [To learn about tsconfig.json file.](https://angular.io/config/tsconfig.)
> 
> - [Angular security best practices.](https://snyk.io/blog/angular-security-best-practices)
> 
> - [DON'T Call Functions Inside The Template Anymore.](https://javascript.plainenglish.io/angular-dont-call-a-function-inside-the-template-anymore-e74ebf499bb8)
> 

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.

----------------------------------------------------------------

# Start work.

```sh
cd ~
curl -sL https://deb.nodesource.com/setup_14.x -o nodesource_setup.sh
sudo bash nodesource_setup.sh
sudo apt install nodejs
npm install
npm install -g @angular/cli

ng new my-app-name
ng g m aaa-name
ng g c aaa-name --skipTests

npm start (# runs ng serve -o  -  see package.json)
```

## The Main Basic Elements are :

### main.ts

```ts
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';

platformBrowserDynamic().bootstrapModule(AppModule)
```

### app.module.ts

```ts
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
```

### app.component.ts

```ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: []
})
export class AppComponent implements OnInit { 
  constructor() { }
  ngOnInit(): void { }
}
```
----------------------------------------------------------------

# NG Routing:

### app-routing.module.ts

```ts
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
```

### app.component.ts

```html
  <nav>
    <a routerLink="/" routerLinkActive="active home" [routerLinkActiveOptions]="{exact:true}">HOME</a>
    <a routerLink="/about" routerLinkActive="active about">ABOUT</a>
  </nav>
  <router-outlet></router-outlet>
```
----------------------------------------------------------------

# @Input - Child's Property from Parent.

### parent.component.html

```html
 <app-child [childProperty]="parentProperty"></app-child>
```

### child.component.ts

```ts
@Input() childProperty;
```
----------------------------------------------------------------

# @Output Child's Event to Parent.

### child.component.ts

```ts
  @Output()
  childEvent: EventEmitter<string> = new EventEmitter();

  textTyping() {
    this.childEvent.emit(this.textInput);
  }
```

### parent.component.html

```html
  <app-child (childEvent)="parentEventHandler($event)"></app-child>
```

### parent.component.ts

```ts
  parentEventHandler(value: someType!) {
    // process value;
  }
```
----------------------------------------------------------------

# @ViewChild, @ViewChildren, @ContentChild

### child.component.html

```html
<p [class.bg]="isBgActive">
  
  <!-- NG-CONTENT - to recieve content from Parent IN PLACE of a tag. -->
  <ng-content></ng-content>

  <input type="button" value="Change Color IF #" (click)="changeMyColor()" />
</p>  
```

### child.component.ts

```ts
@ContentChild('INSIDE_CHILD') childComponentRef!: ElementRef;

changeMyColor() {
  if (this.childComponentRef) {
    this.childComponentRef.nativeElement.style.color = 'red';
  }
}

isBgActive = false;

childsMethod() {
   this.isBgActive = !this.isBgActive;
}
```

### parent.component.html

```html
<app-data-child #CHILDTAG> <!-- @ViewChild to access from Parent -->
   <b>Inside Child Tag.</b>
</app-data-child>

<app-data-child>
    <!-- will send to Child's NG-CONTENT -->
    <b #INSIDE_CHILD>Inside Child Tag.</b> <!-- @ContentChild to access from Child -->
</app-data-child>
```

### parent.component.ts

```ts
  // Find FIRST! 'DataChildComponent'-block :
  @ViewChild(DataChildComponent) firstDCComponent = new DataChildComponent;

  @ViewChild('CHILDTAG') firstDCComponent = new DataChildComponent;
  
  @ViewChildren('CHILDTAG') allDCComponents!: QueryList<any>;

  callFirstChild() {
    this.firstDCComponent.childsMethod();
  }
  callAllChildren() {
    this.allDCComponents.forEach(ch => ch.childsMethod());
  }
```
----------------------------------------------------------------

# Services

### svc.component.html

```html
    <b> {{ componentCounter }} </b>
    &nbsp;
    <input type="button" value="Plus" (click)="plus()" />
```

### svc.component.ts

```ts
  constructor(private mySvc: AaaSvcService) { }

  componentCounter: number = 0;

  plus() {
    this.mySvc.svcIncrement();
    this.componentCounter = this.mySvc.serviceCounter;
  }
```

### svc.service.ts

```ts
@Injectable()
export class AaaSvcService {

  serviceCounter: number = 0;

  svcIncrement() {
    this.serviceCounter++;
  }
```

## Services Registration :

```ts
providers: [ SomeService ] // in APP.MODULE - Globally

providers: [ SomeService ] // in COMPONENT - Locally

@Injectable({providedIn: 'root'}) // in SERVICE - Globally

@Injectable({providedIn: SomeModule}) // in SERVICE - for Whole Module
```
----------------------------------------------------------------

## Service Using in Component:

```ts
@Component({
  // ...
  providers: [SomeService]
})
export class SomeComponent implements OnInit, AfterViewChecked {

  totalSum: number = 0;
  boxes { num: number, name: string } [] = [];

  constructor(
    private service: SomeService,
    private chngDetectRef: ChangeDetectorRef // For ngAfterViewChecked()
  ) { }

  incrementByName(boxName: string) {
    this.service.svcIncrement(boxName);
  }

  ngOnInit(): void {
    // Bind to Service data for process by Service.
    this.service.svcBoxesStorage = this.boxes;
  }

  ngAfterViewChecked(): void {
    this.totalSum = this.service.countUp();
    // To prevent - Expression has changed after it was checked error.
    this.chngDetectRef.detectChanges();
  }
}
```
----------------------------------------------------------------

# RxJS included.

### IntervalsRunner.Component.ts

```ts
import { interval, Subscription } from 'rxjs';

@Component({/*...*/})
export class IntervalComponent implements OnDestroy {
  oneSecondsInterval;
  threeSecondsInterval: Subscription | undefined;

  constructor() {
    this.oneSecondsInterval =
      interval(1000).subscribe((value) => { console.log("1", value);});
  }
  toggleAnotherInterval() {
    this.threeSecondsInterval = interval(3000).subscribe((value) => {console.log("3", value);});
  }
  ngOnDestroy() {
    this.oneSecondsInterval.unsubscribe();
    if (this.threeSecondsInterval)
      this.threeSecondsInterval.unsubscribe();
  }
```

### Data.Service.ts

```ts
import { delay } from 'rxjs/internal/operators';
import { map } from 'rxjs/operators';
import { of } from 'rxjs'; // Works with Streams to handle changes.

@Injectable({providedIn: 'root'})
export class ServerDataService {
  constructor() { }
  getData() {
    // syncronous work.
    let data = [];
    for (let i = 0; i < 6; i++) {
      ++i;
      data.push('A-' + i + i + i);
    };
    // asyncronous work.
    return of(data) // Stream created here.
      .pipe(
        delay(3000),
        map(text => {
          return text.concat("+ One yet item to list.")
        }),
        delay(3000)
      );
  }
```

### DataServiceCustomer.Component.ts

```ts
import { ServerDataService } from '../services/server-data.service';

@Component({/*...*/})
export class OperatorsComponent implements OnInit {
  list: any;
  constructor(private dbService: ServerDataService) { }
  ngOnInit(): void {
    this.dbService.getData().subscribe(data => this.list = data);
  }
```

----------------------------------------------------------------

# HttpClient.

### AppModule.ts

```ts
@NgModule({ imports: [ HttpClientModule, ... ] from '@angular/common/http';
```

### Data.Service.ts

```ts
// Register in AppModule REQUIRED! (see above).
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class GetDataService {
  constructor(private http: HttpClient) { }
  getDataFromService() {
    // returns Observable object (to wait for response).
    return this.http.get('https://jsonplaceholder.typicode.com/users');
```

# HttpClient (Fake WebAPI)

### AppModule.ts

```ts
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
@NgModule({
  imports: [
    // npm install --save angular-in-memory-web-api (REQUIRED!)
    InMemoryWebApiModule.forRoot(BackendSvcService, { delay: 700 }),
```

### FakeBackend.Service.ts

```ts
import { InMemoryDbService } from 'angular-in-memory-web-api';
// Fake-Backend will be accessible at - /api/todos
@Injectable({ /*...*/ })
export class FakeBackendService implements InMemoryDbService {
  createDb() {
    let todos = [
      { id: 1, name: "Task 1" },
      { id: 2, name: "Task 2" },
      { id: 3, name: "Task 3" },
      { id: 4, name: "Task 4" }
    ];
  return { todos: todos };
```

### Todo.Service.ts (FakeBackend consumer)

```ts
import { HttpClient } from '@angular/common/http';

@Injectable({/*...*/})
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
```

### Todo.Component.ts (Todod.Service consumer)

```ts
import { TodoSvcService } from './services/todo-svc.service';

@Component({/*...*/})
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
```

PAUSED - 11:35
