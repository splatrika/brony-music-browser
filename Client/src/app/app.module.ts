import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchFormModule } from './search-form/search-form.module';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { SongsListModule } from './songs-list/songs-list.module';
import { PlayerModule } from './player/player.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    ReactiveFormsModule,
    CoreModule,
    SearchFormModule,
    SongsListModule,
    PlayerModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
