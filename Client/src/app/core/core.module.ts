import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { ArtistsService } from './services/data/artists.service';
import { CharactersService } from './services/data/characters.service';
import { GenresService } from './services/data/genres.service';
import { SongsService } from './services/data/songs.service';
import { AlbumsService } from './services/data/albums.service';
import { PlayerService } from './services/player.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    ArtistsService,
    CharactersService,
    GenresService,
    SongsService,
    AlbumsService,
    PlayerService
  ]
})
export class CoreModule { }
