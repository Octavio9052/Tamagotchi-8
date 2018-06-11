import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctosComponent } from './doctos.component';

describe('DoctosComponent', () => {
  let component: DoctosComponent;
  let fixture: ComponentFixture<DoctosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DoctosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
