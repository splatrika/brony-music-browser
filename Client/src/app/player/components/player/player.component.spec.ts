import { Injectable } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { PlayerService } from 'src/app/core/services/player.service';

import { PlayerComponent } from './player.component';

describe('PlayerComponent', () => {
  let component: PlayerComponent;
  let fixture: ComponentFixture<PlayerComponent>;

  @Injectable()
  class MockPlayerService {
    playRequested$ = new Observable<string>(subscriber => {
      subscriber.next('fake');
    })
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlayerComponent ],
      providers: [
        { provide: PlayerService, useClass: MockPlayerService }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render player', () => {
    let element = fixture.nativeElement as HTMLElement;
    let playerComponent = element.querySelector('iframe');
    expect(playerComponent?.src).toContain('https://youtube.com/embed/fake');
  });
});
