import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { GroupComponent } from './components/group/group.component';
import { CheckboxComponent } from './components/checkbox/checkbox.component';
import { PonyCheckboxComponent } from './components/pony-checkbox/pony-checkbox.component';

@NgModule({
  declarations: [
    GroupComponent,
    CheckboxComponent,
    PonyCheckboxComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    GroupComponent,
    CheckboxComponent,
    PonyCheckboxComponent
  ]
})
export class SharedModule { }
