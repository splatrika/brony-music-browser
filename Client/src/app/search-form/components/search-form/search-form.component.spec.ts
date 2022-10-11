import { Component } from '@angular/core';
import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { SongFilters } from 'src/app/core/models/song-filters.model';

import { SearchFormComponent } from './search-form.component';

describe('SearchFormComponent', () => {
  let component: SearchFormComponent;
  let fixture: ComponentFixture<SearchFormComponent>;

  class MockListSelectBase implements ControlValueAccessor {
    writeValue(obj: any): void {}
    registerOnChange(fn: any): void {}
    registerOnTouched(fn: any): void {}
    setDisabledState?(isDisabled: boolean): void {}
  }

  @Component({
    selector: 'genres',
    providers: [
      {
        provide: NG_VALUE_ACCESSOR,
        multi: true,
        useExisting: MockGenresComponent
      },
    ]
  })
  class MockGenresComponent extends MockListSelectBase {}

  @Component({
    selector: 'characters',
    providers: [
      {
        provide: NG_VALUE_ACCESSOR,
        multi: true,
        useExisting: MockCharactersComponent
      },
    ]
  })
  class MockCharactersComponent extends MockListSelectBase {}

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ 
        SearchFormComponent,
        MockGenresComponent,
        MockCharactersComponent,
      ],
      imports: [
        ReactiveFormsModule
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('submitted should be emited on search button click', fakeAsync(() => {
    spyOn(component.submitted, 'emit');
    
    let element = fixture.nativeElement as HTMLElement;
    let buttonElement = element.querySelector('button');
    buttonElement?.click();
    tick();

    expect(component.submitted.emit).toHaveBeenCalled();
  }));

  it('form data should be passed to submitted event', fakeAsync(() => {
    spyOn(component.submitted, 'emit');

    let formData = component.form.value as SongFilters;
    let element = fixture.nativeElement as HTMLElement;
    let buttonElement = element.querySelector('button');
    buttonElement?.click();
    tick();
    
    expect(component.submitted.emit).toHaveBeenCalledWith(formData);
  }))
});
