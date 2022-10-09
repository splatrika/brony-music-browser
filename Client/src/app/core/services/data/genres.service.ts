import { Injectable } from '@angular/core';
import { Genre } from '../../models/genre.model';
import { SimpleResourceServiceBase } from './simple-resources.service.base';

@Injectable()
export class GenresService extends SimpleResourceServiceBase<Genre> {
  getResourceName(): string {
    return 'Genres';
  }
}
