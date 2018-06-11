import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DocdevComponent } from './docdev.component';

describe('DocdevComponent', () => {
  let component: DocdevComponent;
  let fixture: ComponentFixture<DocdevComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DocdevComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DocdevComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
