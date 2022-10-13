import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { SimpleResourceServiceBase } from './data/simple-resources.service.base';

export interface ShowMoreContext<T> {
  dataService: SimpleResourceServiceBase<any>;
  addCallback: (adding: T) => void;
  captionGetter: (entity: T) => string;
  addedIds: number[];
  resourceName: string;
}

@Injectable()
export class ShowMoreService {
  private showMoreRequestedSource =
    new BehaviorSubject<ShowMoreContext<any> | null>(null);

  showMoreRequested = this.showMoreRequestedSource.asObservable();

  runModal<T>(context: ShowMoreContext<T>) {
    this.showMoreRequestedSource.next(context);
  }
}
