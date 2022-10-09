import { Injectable } from '@angular/core';
import { Character } from '../../models/character.model';
import { SimpleResourceServiceBase } from './simple-resources.service.base';

@Injectable()
export class CharactersService extends SimpleResourceServiceBase<Character> {
  getResourceName(): string {
    return 'Characters';
  }
}
