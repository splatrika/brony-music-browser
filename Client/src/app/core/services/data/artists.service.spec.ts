import { TestBed } from '@angular/core/testing';

import { ArtistsService } from './artists.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Artist } from '../../models/artist.model';
import { apiRoot } from '../../constants';

describe('ArtistsService', () => {
  let service: ArtistsService;
  let httpMock: HttpTestingController

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ArtistsService]
    });
    service = TestBed.inject(ArtistsService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get artist by id', () => {
    let artist: Artist = {id: 2, name: 'EnergyTone'}
    
    service.get(2).subscribe(a => {
      expect(a).toEqual(artist);
    });

    let request = httpMock.expectOne(`${apiRoot}Artists/2`);

    request.flush(artist);

    httpMock.verify();
  });

  it('should get artist with count and offset', () => {
    let artists: Artist[] = [
      {id: 1, name: 'SilvaHound'},
      {id: 2, name: 'EnergyTone'}
    ];

    service.getMany(2, 0).subscribe(a => {
      expect(a).toEqual(artists);
    });

    let request = httpMock.expectOne(`${apiRoot}Artists/?count=2&offset=0`);

    request.flush(artists);

    httpMock.verify();
  });
});
