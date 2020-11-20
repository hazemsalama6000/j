import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestuComponent } from './restu.component';

describe('RestuComponent', () => {
  let component: RestuComponent;
  let fixture: ComponentFixture<RestuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
