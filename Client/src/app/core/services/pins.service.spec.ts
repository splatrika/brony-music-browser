import { TestBed } from '@angular/core/testing';

import { PinsService } from './pins.service';

// todo 
describe('PinsService', () => {
  let service: PinsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ PinsService ]
    });
    service = TestBed.inject(PinsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
