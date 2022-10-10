import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { GroupComponent } from './components/group/group.component';

@NgModule({
  declarations: [
    GroupComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    GroupComponent
  ]
})
export class SharedModule { }
