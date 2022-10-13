import { Component, OnInit } from '@angular/core';
import {
  ControlValueAccessor,
  FormControl,
  NG_VALUE_ACCESSOR,
} from '@angular/forms';
import { Character } from 'src/app/core/models/character.model';
import { CharactersService } from 'src/app/core/services/data/characters.service';
import { SimpleResourceServiceBase } from 'src/app/core/services/data/simple-resources.service.base';

@Component({
  selector: 'characters',
  templateUrl: './characters.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: CharactersComponent,
    },
    {
      provide: SimpleResourceServiceBase<any>,
      useClass: CharactersService,
    },
  ],
})
export class CharactersComponent implements ControlValueAccessor {
  control = new FormControl<number[]>([]);

  writeValue(obj: number[]): void {
    this.control.setValue(obj);
  }

  registerOnChange(fn: any): void {
    this.control.valueChanges.subscribe((x) => fn(x));
  }

  registerOnTouched(fn: any): void {}

  setDisabledState?(isDisabled: boolean): void {
    if (isDisabled) {
      this.control.disable();
    } else {
      this.control.enable();
    }
  }

  getView(character: Character) {
    return character.name;
  }
}
