import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'checkbox',
  templateUrl: './checkbox.component.html'
})
export class CheckboxComponent implements OnInit {
  @Input()
  control!: FormControl<boolean>;

  @Input()
  caption!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
