import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'group',
  templateUrl: './group.component.html'
})
export class GroupComponent implements OnInit {
  @Input()
  title!: string;

  constructor() { }

  ngOnInit(): void {
  }

}
