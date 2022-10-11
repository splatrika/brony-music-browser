import { Component, ContentChild, Input, OnInit, TemplateRef } from '@angular/core';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { SimpleResourceServiceBase } from 'src/app/core/services/data/simple-resources.service.base';

type State = 'loading' | 'complete' | 'error';

@Component({
  selector: 'list-select-control',
  templateUrl: './list-select-control.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: ListSelectControlComponent
    },
  ]
})
export class ListSelectControlComponent implements OnInit, ControlValueAccessor {
  @Input()
  defaultCount = 10;

  @ContentChild(TemplateRef)
  templateRef!: TemplateRef<any>;

  constructor(private service: SimpleResourceServiceBase<any>) { }

  items: any[] = []
  
  private controls = new Map<number, FormControl<boolean>>();
  private selectedItems: any[] = []
  private isDisabled = false;
  private onChange = (i: any[]) => {}
  private state: State = 'loading'

  getState(): State {
    return this.state
  }

  getSelectedItems(): number[] {
    let cloned = Object.assign([], this.selectedItems);
    return cloned;
  }

  getControl(itemId : number): FormControl<boolean> {
    return this.controls.get(itemId) as FormControl<boolean>;
  }

  ngOnInit(): void {
    this.service.getMany(this.defaultCount, 0)
      .subscribe({
        next: n => n.forEach(x => this.addItem(x)),
        error: e => { 
          this.state = 'error'
          console.error(e);
        },
        complete: () => this.state = 'complete'
      });
  }

  writeValue(obj: any): void {
    this.controls.forEach(c => c.setValue(false));
    for (let itemId of obj) {
      if (!this.controls.has(itemId)) {
        console.warn(`There is no genre with id ${itemId}`);
        continue;
      }
      this.controls.get(itemId)!.setValue(true);
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {}

  setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
    if (isDisabled) {
      this.controls.forEach(x => x.disable())
    }
    else {
      this.controls.forEach(x => x.enable());
    }
  }

  private addItem(item: any) {
    this.items.push(item);
    let control = new FormControl(false) as FormControl<boolean>;
    this.controls.set(item.id, control);
    if (this.isDisabled) {
      control.disable();
    }
    control.valueChanges.subscribe(x => this.onValueChange(item.id, x));

  }

  private onValueChange(itemId: number, value: boolean) {
    let itemIndex = this.selectedItems.indexOf((itemId))
    if (value && itemIndex == -1) {
      this.selectedItems.push(itemId);
    }
    else if (!value && itemId != -1) {
      this.selectedItems.splice(itemIndex, 1);
    }
    let cloned = Object.assign([], this.selectedItems);
    this.onChange(cloned);
  }

}
