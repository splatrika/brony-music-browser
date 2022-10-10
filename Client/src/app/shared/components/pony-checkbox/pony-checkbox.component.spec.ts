import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormControl } from '@angular/forms';

import { PonyCheckboxComponent } from './pony-checkbox.component';

describe('PonyCheckboxComponent', () => {
  let component: PonyCheckboxComponent;
  let fixture: ComponentFixture<PonyCheckboxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PonyCheckboxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PonyCheckboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should apply icon url', () => {
    component.iconUrl = '/cover1.png';
    fixture.detectChanges();

    let element = fixture.nativeElement as HTMLElement;
    let inputElement = element.querySelector('.pony-checkbox') as HTMLElement;
    expect(inputElement.style.backgroundImage).toEqual('url("/cover1.png")')
  });

  it('background size should be cover', () => {
    let element = fixture.nativeElement as HTMLElement;
    let inputElement = element.querySelector('.pony-checkbox') as HTMLElement;
    expect(getComputedStyle(inputElement).backgroundSize).toEqual('cover');
  });

  it('form control should be assigned to input', () => {
    let control = 
      new FormControl<boolean>(false) as FormControl<boolean>;
    component.control = control;
    fixture.detectChanges();

    control.setValue(true);
    
    let element = fixture.nativeElement as HTMLElement;
    let inputElement = element.querySelector('input');
    expect(inputElement?.value).toEqual('on');
  })
});
