import { Component, ComponentRef, ContentChild, Input, ViewChild } from '@angular/core';
import { ControlValueAccessor, FormArray, FormControl, FormGroup, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Genre } from 'src/app/core/models/genre.model';
import { GenresService } from 'src/app/core/services/data/genres.service';
import { SimpleResourceServiceBase } from 'src/app/core/services/data/simple-resources.service.base';
import { ListItemComponent } from 'src/app/shared/components/list-item/list-item.component';
import { ListSelectControlComponent } from 'src/app/shared/components/list-select-control/list-select-control.component';

@Component({
  selector: 'genres',
  templateUrl: './genres.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: GenresComponent
    },
    {
      provide: SimpleResourceServiceBase<any>,
      useClass: GenresService
    }
  ]
})
export class GenresComponent implements ControlValueAccessor {
  formControl = new FormControl<number[]>([]);

  writeValue(obj: number[]): void {
    this.formControl.setValue(obj);
  }

  registerOnChange(fn: any): void {
    this.formControl.valueChanges
      .subscribe(x => fn(x));
  }

  registerOnTouched(fn: any): void {}

  setDisabledState?(isDisabled: boolean): void {
    if (isDisabled) {
      this.formControl.disable();
    }
    else {
      this.formControl.enable();
    }
  }
}
