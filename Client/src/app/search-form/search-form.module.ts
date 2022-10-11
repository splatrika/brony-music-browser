import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

import { GenresComponent } from './components/genres/genres.component';
import { CharactersComponent } from './components/characters/characters.component';

@NgModule({
  declarations: [
    GenresComponent,
    CharactersComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CoreModule,
    SharedModule
  ],
  exports: []
})
export class SearchFormModule { }
