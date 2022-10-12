import { TestBed } from '@angular/core/testing';

import { PlayerService } from './player.service';

describe('PlayerService', () => {
  let service: PlayerService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PlayerService]
    });
    service = TestBed.inject(PlayerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('playRequested should be emitted with new youtube id on play call', () => {
    let youTubeId: string | null = '';
    service.playRequested$.subscribe(x => youTubeId = x);
    service.play('abcdef');
    expect(youTubeId).toEqual('abcdef');
  });
});
