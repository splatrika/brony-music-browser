import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, NG_VALUE_ACCESSOR } from '@angular/forms';
import { SongFilters } from 'src/app/core/models/song-filters.model';

@Component({
  selector: 'search-form',
  templateUrl: './search-form.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: SearchFormComponent
    },
  ]
})
export class SearchFormComponent {
  @Output()
  submitted = new EventEmitter<SongFilters>();

  form = new FormGroup({
    searchString: new FormControl(''),
    characters: new FormControl<number[]>([]),
    genres: new FormControl<number[]>([])
  });

  onSearchClick() {
    this.submitted.emit(this.form.value as SongFilters);
  }
}
