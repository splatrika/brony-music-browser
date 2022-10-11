import { Component, ComponentRef } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { SimpleResourceServiceBase } from 'src/app/core/services/data/simple-resources.service.base';

import { ListSelectControlComponent } from './list-select-control.component';

describe('ListSelectControlComponent', () => {
  const testValues: any[] = [
    {id: 10},
    {id: 12},
    {id: 14}
  ]
  let requestedCount = 0;
  
  @Component({
    template: `
      <list-select-control>
        <ng-template let-item let-boolControl>
          <p>item.id</p>
          <input id="item-{{ item.id }}" [formControl]="boolControl" />
        </ng-template>
      </list-select-control>
    `
  })
  class TestComponent {}
  
  class MockDataSetvice {
    getMany(count: number, offset: number): Observable<any> {
      requestedCount = count;
      return new Observable(subscriber => {
        subscriber.next(testValues);
        subscriber.complete();
      })
    }
  }

  let component: ListSelectControlComponent;
  let testFixture: ComponentFixture<TestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListSelectControlComponent, TestComponent ], // add test component
      providers: [ {
        provide: SimpleResourceServiceBase<any>, 
        useClass: MockDataSetvice} ]
    })
    .compileComponents();

    testFixture = TestBed.createComponent(TestComponent);
    component = testFixture.debugElement
      .query(By.css('list-select-control'))
      .componentInstance as ListSelectControlComponent;
    component.defaultCount = 5;
    testFixture.detectChanges();

    // instantiate test component
    // get component from test component ??? Or create them separatly
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get values from data service', () => {
    expect(component.items).toEqual(testValues);
  });

  it('should call onChange with updated selections after value has changed', () => {
    let updated: number[] = []
    component.registerOnChange((c: number[]) => updated = c);
    component.getControl(12).setValue(true);
    expect(updated).toEqual([12]);
    component.getControl(10).setValue(true);
    expect(updated).toEqual([12, 10]);
  });

  it('writeValue should update controls', () => {
    component.writeValue([10, 12]);
    expect(component.getControl(10).value).toEqual(true);
    expect(component.getControl(12).value).toEqual(true);
  });

  it('writeValue should update values', () => {
    component.writeValue([10, 12]);
    expect(component.getSelectedItems()).toEqual([10, 12]);
  });

  it('should project checkboxes', () => {
    let element = testFixture.debugElement
      .query(By.css('list-select-control'))
      .nativeElement as HTMLElement;
    let inputElement = element.querySelector('#item-12');
    expect(inputElement).toBeTruthy();
  });

  it('should pass defaultCount to request', () => {
    expect(requestedCount).toEqual(5);
  })
});
