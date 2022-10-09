import { Injectable } from '@angular/core';
import { Artist } from '../../models/artist.model';
import { SimpleResourceServiceBase } from './simple-resources.service.base';

@Injectable()
export class ArtistsService extends SimpleResourceServiceBase<Artist> {
  getResourceName(): string {
    return 'Artists';
  }
}
