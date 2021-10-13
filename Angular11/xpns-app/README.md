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

```
npm install -g @angular/cli

ng new my-app-name
ng g m aaa-name
ng g c aaa-name --skipTests

npm start (# runs ng serve -o  -  see package.json)
```

## The Main Basic Elements are :

### main.ts
```
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';

platformBrowserDynamic().bootstrapModule(AppModule)
```

### app.module.ts
```
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
```
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
```
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
```
  <nav>
    <a routerLink="/" routerLinkActive="active home" [routerLinkActiveOptions]="{exact:true}">HOME</a>
    <a routerLink="/about" routerLinkActive="active about">ABOUT</a>
  </nav>
  <router-outlet></router-outlet>
```
----------------------------------------------------------------

# Inheritance (parent to child).

### parent.component.html
```
 <app-child [childProperty]="parentProperty"></app-child>
```

### child.component.ts
```
@Input() childProperty;
```

# Inheritance (child to parent).

### child.component.ts
```
  @Output()
  childEvent: EventEmitter<string> = new EventEmitter();

  textType() {
    this.childEvent.emit(this.textInput);
  }
```

### parent.component.html
```
<app-child (childEvent)="parentEventHandler($event)"></app-child>
```

### parent.component.ts
```
  parentEventHandler(value: someType!) {
    // process value;
  }
```
