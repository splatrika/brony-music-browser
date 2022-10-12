import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Song } from 'src/app/core/models/song.model';
import { ArtistsService } from 'src/app/core/services/data/artists.service';
import { SongsService } from 'src/app/core/services/data/songs.service';
import { SongListSpecification } from '../../intrefaces/song-list-specification';
import { AllSongsSpecification } from '../../specifications/all-songs.specification';

type State = 'loading' | 'complete' | 'error';

@Component({
  selector: 'songs-list',
  templateUrl: './songs-list.component.html'
})
export class SongsListComponent implements OnInit, OnChanges {
  @Input()
  specification : SongListSpecification = new AllSongsSpecification();

  songs: Song[] = []
  
  private state: State = 'loading';

  constructor(
    private service: SongsService) { }

  isNotFound(): boolean {
    return this.state == 'complete' && this.songs.length == 0;
  }

  getState(): State {
    return this.state;
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['specification']) {
      this.update();
    }
  }

  ngOnInit(): void {
    this.update();
  }

  private update() {
    this.songs = [];
    this.state = 'loading'
    this.specification.get(this.service, 10, 0)
      .subscribe({
        next: n => this.songs = n,
        error: e => this.state = 'error',
        complete: () => this.state = 'complete'
      });
  }
}
