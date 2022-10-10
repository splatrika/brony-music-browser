import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'item-button',
  templateUrl: './item-button.component.html'
})
export class ItemButtonComponent {
  @Input()
  iconUrl!: string;

  @Output()
  clicked = new EventEmitter();

  click() {
    this.clicked.emit();
  }
}
