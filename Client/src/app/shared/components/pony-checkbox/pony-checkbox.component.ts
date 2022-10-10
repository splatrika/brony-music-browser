import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'pony-checkbox',
  templateUrl: './pony-checkbox.component.html',
  styleUrls: ['./pony-checkbox.component.scss']
})
export class PonyCheckboxComponent {
  @Input()
  iconUrl!: string;

  @Input()
  control!: FormControl<boolean>;
}
