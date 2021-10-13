import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-styles-inheritance',
  templateUrl: './styles-inheritance.component.html',
  styleUrls: ['./styles-inheritance.component.css']
})
export class StylesInheritanceComponent {

  parentProperty = 777;

  parentText = '';

  parentHandler(value: string) {
    this.parentText = value;
  }

}
