import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Song } from '../../models/song.model';
import { SongFilters } from '../../models/song-filters.model';
import { SongShort } from '../../models/song-short.model';
import { SimpleResourceServiceBase } from './simple-resources.service.base';

@Injectable()
export class SongsService extends SimpleResourceServiceBase<Song> {
  getResourceName(): string {
    return 'Songs';
  }

  getByFilters(filters: SongFilters, count: number, offset: number): Observable<Song[]> {
    let url = `${this.getRoot()}Search/`;
    let params = new HttpParams({fromObject: filters as any})
      .set("count", count)
      .set('offset', offset)
    return this.http.get<Song[]>(url, {params});
  }

  getShort(id: number): Observable<SongShort> {
    let url = `${this.getRoot()}${id}/Short/`;
    return this.http.get<SongShort>(url);
  }
}
