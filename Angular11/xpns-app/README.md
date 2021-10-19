# Just NG XpnsApp.

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 12.2.8.

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

```bsh
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
  <!-- To recieve content from Parent IN PLACE of a tag. -->
  <ng-content></ng-content>
  <input type="button" value="Change Color IF #" (click)="changeMyColor()" />
```

### child.component.ts

```ts
  @ContentChild('strInsideAppChildTag') childComponentRef!: ElementRef;

  changeMyColor() {
    if (this.childComponentRef) {
      this.childComponentRef.nativeElement.style.color = 'red';
    }
  }

  isBgActive = false;
  childSwitchMethod() {
    this.isBgActive = !this.isBgActive;
  }
```

### parent.component.html

```html
  <app-data-child> 
      <b #insideAppTag>Inside Child Tag.</b>
  </app-data-child>

  <app-data-child #taggedChild>
      <b>Inside Child Tag.</b>
  </app-data-child>
  
  <input type="text" #inputForElementRef /> 




  
```

### parent.component.ts

```ts
  // Find FIRST! 'DataChildComponent'-block :
  @ViewChild(DataChildComponent) firstDCComponent: DataChildComponent = new DataChildComponent;
  @ViewChild('taggedChild') firstDCComponent: DataChildComponent = new DataChildComponent;
  @ViewChildren('taggedChild') allDCComponents!: QueryList<any>;
  @ViewChild('inputForElementRef') textInputRef !: ElementRef;

  callFirstChild() {
    this.firstDCComponent.childSwitchMethod();
  }
  callAllChildren() {
    this.allDCComponents.forEach(ch => ch.childSwitchMethod());
  }
  takeInputsFocus() {
    this.textInputRef.nativeElement.focus();
  }
```
----------------------------------------------------------------