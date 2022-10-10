import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupComponent } from './group.component';

describe('GroupComponent', () => {
  let component: GroupComponent;
  let fixture: ComponentFixture<GroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render title', () => {
    component.title = 'genres';
    fixture.detectChanges();
    let element = fixture.nativeElement as HTMLElement;
    let titleElement = element.querySelector(".group-title");
    expect(titleElement?.innerHTML).toEqual('genres');
  });
});
