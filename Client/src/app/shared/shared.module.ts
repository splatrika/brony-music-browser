import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { GroupComponent } from './components/group/group.component';
import { CheckboxComponent } from './components/checkbox/checkbox.component';
import { PonyCheckboxComponent } from './components/pony-checkbox/pony-checkbox.component';
import { ListItemComponent } from './components/list-item/list-item.component';
import { ItemButtonComponent } from './components/item-button/item-button.component';

@NgModule({
  declarations: [
    GroupComponent,
    CheckboxComponent,
    PonyCheckboxComponent,
    ListItemComponent,
    ItemButtonComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    GroupComponent,
    CheckboxComponent,
    PonyCheckboxComponent,
    ListItemComponent,
    ItemButtonComponent
  ]
})
export class SharedModule { }
