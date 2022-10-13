import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import {
  ShowMoreContext,
  ShowMoreService,
} from 'src/app/core/services/show-more.service';

@Component({
  selector: 'show-more-modal',
  templateUrl: './show-more-modal.component.html',
})
export class ShowMoreModalComponent implements OnInit, OnDestroy {
  private subscription!: Subscription;

  context: ShowMoreContext<any> | null = null;
  items: any[] = [];

  constructor(private service: ShowMoreService) {}

  ngOnInit(): void {
    this.subscription = this.service.showMoreRequested.subscribe((x) =>
      this.onRequest(x)
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  close() {
    this.items = [];
    this.context = null;
  }

  onRequest(context: ShowMoreContext<any> | null) {
    this.context = context;
    if (!context) {
      this.close();
      return;
    }
    context.dataService.getMany(1000, 0).subscribe((loaded) => {
      this.items = loaded.filter((x) => context.addedIds.indexOf(x.id) == -1);
    });
  }

  add(id: number) {
    let selectedIndex = this.items.findIndex((x) => x.id == id);
    let selected = this.items[selectedIndex];
    this.context?.addCallback(selected);
    this.items.splice(selectedIndex, 1);
  }
}
