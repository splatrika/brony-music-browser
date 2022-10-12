import { Component } from '@angular/core';
import { ComponentFixture, TestBed, TestComponentRenderer } from '@angular/core/testing';
import { By } from '@angular/platform-browser';

import { ListItemComponent } from './list-item.component';

@Component({
  selector: 'test',
  template: `
    <list-item>
      <span icon>picture</span>
      <span secondary>Brony musician</span>
      <button buttons>More info</button>
    </list-item>
  `
})
class TestComponent {}

describe('ListItemComponent', () => {
  let component: ListItemComponent;
  let fixture: ComponentFixture<ListItemComponent>;
  let testFixture : ComponentFixture<TestComponent>;
  let testComponent: TestComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestComponent, ListItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

    testFixture = TestBed.createComponent(TestComponent);
    testComponent = testFixture.componentInstance;
    testFixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render title', () => {
    component.title = 'EnergyTone';
    fixture.detectChanges();

    let element = fixture.nativeElement as HTMLElement;
    let titleElement = element.querySelector('.primary');
    expect(titleElement?.innerHTML).toEqual('EnergyTone');
  });

  it('should project a secondary', () => {
    let secondaryContainer = testFixture.debugElement
      .query(By.css('list-item'))
      .query(By.css('.secondary'))
      .nativeElement as HTMLElement;
    expect(secondaryContainer.innerHTML)
      .toContain('Brony musician');
  });

  it('should project a buttons', () => {
    let buttonsContainer = testFixture.debugElement
      .query(By.css('list-item'))
      .query(By.css('.item-buttons'))
      .nativeElement as HTMLElement;
    expect(buttonsContainer.innerHTML)
      .toContain('More info');
  });

  it('should project an icon', () => {
    let buttonsContainer = testFixture.debugElement
      .query(By.css('list-item'))
      .query(By.css('.icon'))
      .nativeElement as HTMLElement;
    expect(buttonsContainer.innerHTML)
      .toContain('picture');
  });
});
