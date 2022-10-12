import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class PlayerService {
  private playRequestedSource = new BehaviorSubject<string | null>(null);

  playRequested$ = this.playRequestedSource.asObservable();

  play(youTubeId: string) {
    this.playRequestedSource.next(youTubeId);
  }
}
