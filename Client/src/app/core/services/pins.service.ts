import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable() // todo implement
export class PinsService {
  pinAdded = new Observable<number>(() => { throw new Error('Not implemented') });

  addPin(songId: number) {
    throw new Error('Method not implemented');
  }

}
