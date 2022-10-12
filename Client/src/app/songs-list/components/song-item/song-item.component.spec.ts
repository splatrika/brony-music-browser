import { Component, EventEmitter, Injectable, Output } from '@angular/core';
import { ComponentFixture, fakeAsync, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Observable, subscribeOn } from 'rxjs';
import { AlbumTitle } from 'src/app/core/models/album-title.model';
import { Artist } from 'src/app/core/models/artist.model';
import { Genre } from 'src/app/core/models/genre.model';
import { AlbumsService } from 'src/app/core/services/data/albums.service';
import { ArtistsService } from 'src/app/core/services/data/artists.service';
import { GenresService } from 'src/app/core/services/data/genres.service';
import { PinsService } from 'src/app/core/services/pins.service';
import { PlayerService } from 'src/app/core/services/player.service';

import { SongItemComponent } from './song-item.component';

describe('SongItemComponent', () => {
  let lastPlayedSongId = '';
  let lastPinned = 0;

  @Injectable()
  class MockPlayerService {
    play(youTubeId: string) {
      lastPlayedSongId = youTubeId;
    }
  }

  @Injectable()
  class MockPinsService {
    addPin(songId : number) {
      lastPinned = songId;
    }
  }

  @Injectable()
  class MockArtistsService {
    get(id: number): Observable<Artist> {
      return new Observable(subscriber => {
        subscriber.next({ id: id, name: 'Squid' });
        subscriber.complete();
      })
    }
  }

  @Injectable()
  class MockGenresService {
    get(id: number): Observable<Genre> {
      return new Observable(subscriber => {
        subscriber.next({ id: id, caption: 'Rock', order: 0 });
        subscriber.complete();
      })
    }
  }

  @Injectable()
  class MockAlbumsService {
    getBySong(songId: number): Observable<AlbumTitle> {
      return new Observable(subscriber => {
        subscriber.next({ id: 0, title: 'Splatoon 3 OST' });
        subscriber.complete();
      })
    }
  }

  @Component({
    selector: 'item-button'
  })
  class MockItemButton {
    @Output()
    clicked = new EventEmitter();

    click() {
      this.clicked.emit();
    }
  }

  let component: SongItemComponent;
  let fixture: ComponentFixture<SongItemComponent>;
  let playButton: MockItemButton;
  let pinButton: MockItemButton;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ 
        SongItemComponent, 
        MockItemButton 
      ],
      providers: [
        { provide: ArtistsService, useClass: MockArtistsService },
        { provide: GenresService, useClass: MockGenresService },
        { provide: AlbumsService, useClass: MockAlbumsService },
        { provide: PlayerService, useClass: MockPlayerService },
        { provide: PinsService, useClass: MockPinsService }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SongItemComponent);
    component = fixture.componentInstance;
    component.song = { 
      id: 101,
      title: 'song101',
      cover: '/',
      year: 2101,
      youTubeId: 'abc123',
      artists: [ 1, 3101 ],
      characters: [],
      genres: [ 3101, 4101 ]
    }
    fixture.detectChanges();

    // todo get buttons
    playButton = fixture.debugElement.query(By.css('.playButton')).componentInstance;
    pinButton = fixture.debugElement.query(By.css('.pinButton')).componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should play track on play button click', fakeAsync(() => {
    playButton.click();
    expect(lastPlayedSongId).toEqual('abc123');
  }));

  it('should add pin on pin button click', fakeAsync(() => {
    pinButton.click();
    expect(lastPinned).toEqual(101);
  }));
});
