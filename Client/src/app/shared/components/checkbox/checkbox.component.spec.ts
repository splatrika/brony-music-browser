import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormControl } from '@angular/forms';

import { CheckboxComponent } from './checkbox.component';

describe('CheckboxComponent', () => {
  let component: CheckboxComponent;
  let fixture: ComponentFixture<CheckboxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CheckboxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CheckboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render caption', () => {
    component.caption = 'item 1';
    fixture.detectChanges();

    let element = fixture.nativeElement as HTMLElement;
    let captionElement = element.querySelector('span');
    expect(captionElement?.innerHTML).toEqual('item 1');
  });

  it('form control should be assigned to input', () => {
    let control = new FormControl<boolean>(false);
    component.control = control;
    fixture.detectChanges();

    control.setValue(true);
    
    let element = fixture.nativeElement as HTMLElement;
    let inputElement = element.querySelector('input');
    expect(inputElement?.value).toEqual('on');
  })
});
