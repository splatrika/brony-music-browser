import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { PlayerService } from 'src/app/core/services/player.service';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.scss']
})
export class PlayerComponent implements OnInit, OnDestroy {
  // private youTubeId: string | null = null
  player?: SafeResourceUrl
  private subscribtion!: Subscription;

  constructor(
    private service: PlayerService,
    private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.subscribtion = this.service.playRequested$.subscribe(x => {
      if (x == null) {
        this.player = undefined;
        return;
      }
      this.player = this.getPlayer(x);
    })
  }

  ngOnDestroy(): void {
    this.subscribtion.unsubscribe();
  }

  hasSongToPlay(): boolean {
    return this.player != undefined;
  }

  private getPlayer(id: string): SafeResourceUrl {
    return this.sanitizer.bypassSecurityTrustResourceUrl(
      `https://youtube.com/embed/${id}?autoplay=1`);
  }
}
