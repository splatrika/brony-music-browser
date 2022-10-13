import { Injectable } from '@angular/core';
import {
  ComponentFixture,
  fakeAsync,
  TestBed,
  tick,
} from '@angular/core/testing';
import { Observable } from 'rxjs';
import { SimpleResourceServiceBase } from 'src/app/core/services/data/simple-resources.service.base';
import {
  ShowMoreContext,
  ShowMoreService,
} from 'src/app/core/services/show-more.service';

import { ShowMoreModalComponent } from './show-more-modal.component';

describe('ShowMoreModalComponent', () => {
  let lastAdded: any = null;

  class MockDataService {
    getMany(count: number, offset: number): Observable<any> {
      return new Observable((subscriber) => {
        subscriber.next([
          {
            id: 1,
          },
          {
            id: 2,
          },
          {
            id: 3,
          },
          {
            id: 4,
          },
        ]);
      });
    }
  }

  @Injectable()
  class MockShowMoreService {
    showMoreRequested = new Observable<ShowMoreContext<any> | null>(
      (subscriber) => {
        subscriber.next({
          dataService:
            new MockDataService() as unknown as SimpleResourceServiceBase<any>,
          addCallback: (x) => {
            lastAdded = x;
          },
          captionGetter: (x) => 'caption',
          addedIds: [1, 2],
          resourceName: 'test',
        });
      }
    );
  }

  let component: ShowMoreModalComponent;
  let fixture: ComponentFixture<ShowMoreModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowMoreModalComponent],
      providers: [{ provide: ShowMoreService, useClass: MockShowMoreService }],
    }).compileComponents();

    fixture = TestBed.createComponent(ShowMoreModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should be showed on service request', () => {
    expect(component.context).not.toEqual(null);
  });

  it('should get items from data service', () => {
    expect(component.items.length).not.toEqual(0);
  });

  it('should exclude ids given in context.addedIds', () => {
    let itemsIds = component.items.map((x) => x.id);
    expect(itemsIds).toEqual(jasmine.arrayWithExactContents([3, 4]));
  });

  it('should call add callback on add button click', fakeAsync(() => {
    let element = fixture.nativeElement as HTMLElement;
    let addButton = element.querySelector('.add-item') as HTMLButtonElement;
    addButton?.click();
    tick();

    fixture.detectChanges();
    expect(lastAdded).not.toEqual(null);
  }));

  it('should close on close button click', fakeAsync(() => {
    let element = fixture.nativeElement as HTMLElement;
    let closeButton = element.querySelector(
      '.close-button'
    ) as HTMLButtonElement;

    closeButton.click();
    tick();

    fixture.detectChanges();
    expect(component.context).toEqual(null);
  }));
});
