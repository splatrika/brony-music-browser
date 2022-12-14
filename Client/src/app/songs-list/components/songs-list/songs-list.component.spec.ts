import {
  Component,
  Directive,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { Song } from 'src/app/core/models/song.model';
import { SongsService } from 'src/app/core/services/data/songs.service';
import { SongListSpecification } from '../../intrefaces/song-list-specification';
import { SongItemComponent } from '../song-item/song-item.component';

import { SongsListComponent } from './songs-list.component';

describe('SongsListComponent', () => {
  let fakeSongs: Song[] = [
    {
      id: 1,
      title: '',
      year: 0,
      cover: '',
      youTubeId: '',
      artists: [],
      characters: [],
      genres: [],
    },
    {
      id: 2,
      title: '',
      year: 0,
      cover: '',
      youTubeId: '',
      artists: [],
      characters: [],
      genres: [],
    },
  ];

  class MockSongsService {}

  class MockSpecification implements SongListSpecification {
    get(
      service: SongsService,
      count: number,
      offset: number
    ): Observable<Song[]> {
      return new Observable((subscriber) => {
        subscriber.next(fakeSongs);
        subscriber.complete();
      });
    }
  }

  @Component({
    selector: 'song-item',
  })
  class MockSongItemComponent {
    @Input()
    song!: Song;
  }

  let component: SongsListComponent;
  let fixture: ComponentFixture<SongsListComponent>;
  let itemComponents: SongItemComponent[];

  @Directive({
    selector: '[infinite-scroll]',
  })
  class MockInfiniteScrollDirective {
    @Input()
    infiniteScrollDistance!: number;

    @Input()
    infiniteScrollUpDistance!: number;

    @Input()
    infiniteScrollThrottle!: number;

    @Input()
    scrollWindow!: boolean;

    @Input()
    immediateCheck!: boolean;

    @Input()
    infiniteScrollDisabled!: boolean;

    @Input()
    horizontal!: boolean;

    @Input()
    alwaysCallback!: boolean;

    @Input()
    infiniteScrollContainer!: string | HTMLElement;

    @Input()
    fromRoot!: boolean;

    @Output()
    scrolled = new EventEmitter();

    @Output()
    scrolledUp = new EventEmitter();
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        SongsListComponent,
        MockSongItemComponent,
        MockInfiniteScrollDirective,
      ],
      providers: [{ provide: SongsService, useClass: MockSongsService }],
    }).compileComponents();

    fixture = TestBed.createComponent(SongsListComponent);
    component = fixture.componentInstance;
    component.specification = new MockSpecification();
    fixture.detectChanges();
    let items = fixture.debugElement.queryAll(By.css('song-item'));
    itemComponents = items.map((i) => i.componentInstance);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get songs from data service', () => {
    expect(component.songs).toEqual(fakeSongs);
  });

  it('should render items', () => {
    expect(itemComponents.length).toBe(fakeSongs.length);
  });

  it('should pass songs to items', () => {
    let passedSongs = itemComponents.map((i) => i.song);
    expect(passedSongs).toEqual(jasmine.arrayWithExactContents(fakeSongs));
  });

  it('should load songs on scroll', () => {
    spyOn(component.specification, 'get').and.callThrough();
    component.onScroll();
    expect(component.specification.get).toHaveBeenCalledWith(
      jasmine.anything(),
      component.defaultCount + 2,
      2
    );
  });
});
