import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { SongFilters } from './core/models/song-filters.model';
import { SongListSpecification } from './songs-list/intrefaces/song-list-specification';
import { AllSongsSpecification } from './songs-list/specifications/all-songs.specification';
import { ByFiltersSpecification } from './songs-list/specifications/by-filters.specification';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BronyMusicBrowser';

  songListSpecification: SongListSpecification = new AllSongsSpecification();

  genresControl = new FormControl<number[]>([]) as FormControl<number[]>;
  charactersControl = new FormControl<number[]>([]) as FormControl<number[]>;

  onSearchSubmitted(filters: SongFilters) {
    this.songListSpecification = new ByFiltersSpecification(filters);
  }
}
