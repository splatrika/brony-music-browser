import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SongsListComponent } from './components/songs-list/songs-list.component';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';
import { SongItemComponent } from './components/song-item/song-item.component';



@NgModule({
  declarations: [
    SongsListComponent,
    SongItemComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    SharedModule
  ],
  exports: [
    SongsListComponent
  ]
})
export class SongsListModule { }
