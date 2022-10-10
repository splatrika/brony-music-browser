import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';

import { ItemButtonComponent } from './item-button.component';

describe('ItemButtonComponent', () => {
  let component: ItemButtonComponent;
  let fixture: ComponentFixture<ItemButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemButtonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call click on button click', fakeAsync(() => {
    spyOn(component, 'click');

    let element = fixture.nativeElement as HTMLElement;
    let buttonElement = element.querySelector('button');

    buttonElement?.click();
    tick();

    expect(component.click).toHaveBeenCalled();
  }));

  it('should emit clicked on click call', () => {
    spyOn(component.clicked, 'emit');
    component.click();
    expect(component.clicked.emit).toHaveBeenCalled();
  });

  it('should apply icon url', () => {
    component.iconUrl = '/characters/pinkie-pie.png';
    fixture.detectChanges();

    let element = fixture.nativeElement as HTMLElement;
    let iconElement = element.querySelector('img');
    expect(iconElement?.src).toContain('/characters/pinkie-pie.png');
  });
});
