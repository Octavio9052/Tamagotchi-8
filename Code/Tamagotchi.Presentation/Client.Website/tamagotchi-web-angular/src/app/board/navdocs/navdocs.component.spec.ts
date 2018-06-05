import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavdocsComponent } from './navdocs.component';

describe('NavdocsComponent', () => {
  let component: NavdocsComponent;
  let fixture: ComponentFixture<NavdocsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavdocsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavdocsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
