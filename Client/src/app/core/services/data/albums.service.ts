import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Album } from '../../models/album.model';
import { AlbumTitle } from '../../models/album-title.model';
import { SimpleResourceServiceBase } from './simple-resources.service.base';

@Injectable()
export class AlbumsService extends SimpleResourceServiceBase<Album> {
  getResourceName(): string {
    return 'Albums';
  }

  getTitle(id: number): Observable<AlbumTitle> {
    let url = `${this.getRoot()}${id}/Title/`;
    return this.http.get<AlbumTitle>(url);
  }

  getBySong(songId: number): Observable<AlbumTitle> {
    let url = `${this.getRoot()}BySong/${songId}/`;
    return this.http.get<AlbumTitle>(url);
  }
}
