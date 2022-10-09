import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { apiRoot } from '../../constants';
import { AlbumTitle } from '../../models/album-title.model';

import { AlbumsService } from './albums.service';

describe('AlbumsService', () => {
  let service: AlbumsService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [AlbumsService]
    });
    service = TestBed.inject(AlbumsService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get album title by id', () => {
    let album: AlbumTitle = {id: 10, title: 'The Magic Flicker'};
    
    service.getTitle(10).subscribe(a => {
      expect(a).toEqual(album);
    })

    let request = httpMock.expectOne(`${apiRoot}Albums/10/Title/`);

    request.flush(album);

    httpMock.verify();
  });

  it('should get album title by song id', () => {
    let album: AlbumTitle = {id: 10, title: 'The Magic Flicker'};

    service.getBySong(5).subscribe(a => {
      expect(a).toEqual(album);
    });

    let request = httpMock.expectOne(`${apiRoot}Albums/BySong/5/`);

    request.flush(album);

    httpMock.verify();
  });
});
