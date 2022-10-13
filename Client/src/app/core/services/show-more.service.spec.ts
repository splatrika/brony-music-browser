import { TestBed } from '@angular/core/testing';
import { SimpleResourceServiceBase } from './data/simple-resources.service.base';

import { ShowMoreContext, ShowMoreService } from './show-more.service';

describe('ShowMoreService', () => {
  let service: ShowMoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ShowMoreService],
    });
    service = TestBed.inject(ShowMoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should emit showMoreRequested with context on runModel call', () => {
    let exceptedContext: ShowMoreContext<any> | null = {
      dataService: { test: 1 } as unknown as SimpleResourceServiceBase<any>,
      addCallback: (x) => console.log(x),
      captionGetter: (_) => 'hi!',
      addedIds: [4, 5],
      resourceName: 'test',
    };
    let actualContext: any = null;
    service.showMoreRequested.subscribe((x) => (actualContext = x));
    service.runModal(exceptedContext);
    expect(actualContext).toBe(exceptedContext);
  });
});
