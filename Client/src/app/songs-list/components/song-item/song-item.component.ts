import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { AlbumTitle } from 'src/app/core/models/album-title.model';
import { Artist } from 'src/app/core/models/artist.model';
import { Genre } from 'src/app/core/models/genre.model';
import { Song } from 'src/app/core/models/song.model';
import { AlbumsService } from 'src/app/core/services/data/albums.service';
import { ArtistsService } from 'src/app/core/services/data/artists.service';
import { GenresService } from 'src/app/core/services/data/genres.service';
import { PinsService } from 'src/app/core/services/pins.service';
import { PlayerService } from 'src/app/core/services/player.service';

@Component({
  selector: 'song-item',
  templateUrl: './song-item.component.html',
  styleUrls: ['./song-item.component.scss']
})
export class SongItemComponent implements OnChanges {
  @Input()
  song!: Song;

  @Input()
  artistsCount = 2;

  @Input()
  genresCount = 2;

  artists?: Artist[]
  genres? : Genre[]
  album?: AlbumTitle

  constructor(
    private artistsService: ArtistsService,
    private genresService: GenresService,
    private albumService: AlbumsService,
    private player: PlayerService,
    private pins: PinsService) { }

  
  ngOnChanges(changes: SimpleChanges): void {
    this.loadArtists();
    this.loadGenres();
    this.loadAlbum();
  }

  onPlayClick() {
    this.player.play(this.song.youTubeId);
  }

  onPinClick() {
    this.pins.addPin(this.song.id);
  }

  private loadArtists() {
    this.artists = [];
    let selected = this.song.artists.slice(0, this.artistsCount);
    for (let a of selected) {
      this.artistsService.get(a)
        .subscribe(x => this.artists?.push(x))
    }
  }

  private loadGenres() {
    this.genres = [];
    let selected = this.song.genres.slice(0, this.genresCount);
    for (let g of selected) {
      this.genresService.get(g)
        .subscribe(x => this.genres?.push(x));
    }
  }

  private loadAlbum() {
    this.album = undefined;
    this.albumService.getBySong(this.song.id)
      .subscribe(x => this.album = x);
  }
}
