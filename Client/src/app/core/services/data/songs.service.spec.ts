import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { apiRoot } from '../../constants';
import { Song } from '../../models/song.model';
import { SongFilters } from '../../models/song-filters.model';
import { SongShort } from '../../models/song-short.model';

import { SongsService } from './songs.service';

describe('SongsService', () => {
  let service: SongsService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [SongsService]
    });
    service = TestBed.inject(SongsService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get short song info by id', () => {
    let song: SongShort = {id: 10, title: 'The Magic Flicker', artists: [ 4 ]};
    
    service.getShort(10).subscribe(s => {
      expect(s).toEqual(song);
    });

    let request = httpMock.expectOne(`${apiRoot}Songs/10/Short/`);

    request.flush(song);

    httpMock.verify();
  });

  it('should get song by filters', () => {
    let songs: Song[] = [
      {
        id: 1,
        title: 'The Magic Flicker',
        cover: '/cover1.png',
        youTubeId: '123',
        year: 2018,
        artists: [4],
        characters: [87],
        genres: [ 4, 6 ]
      }
    ]

    let filters: SongFilters = {
      searchString: 'magic',
      genres: [6],
      characters: [3, 87]
    };

    service.getByFilters(filters, 10, 0).subscribe(s => {
      expect(s).toEqual(songs);
    });

    let request = httpMock.expectOne(
      `${apiRoot}Songs/Search/?searchString=magic&genres=6&characters=3&characters=87` +
      '&count=10&offset=0');
    
    request.flush(songs);

    httpMock.verify();
  })
});
