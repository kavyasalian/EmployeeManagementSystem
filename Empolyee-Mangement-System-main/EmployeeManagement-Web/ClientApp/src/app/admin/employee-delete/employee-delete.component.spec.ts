import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeDeleteComponent } from './employee-delete.component';

describe('EmployeeDeleteComponent', () => {
  let component: EmployeeDeleteComponent;
  let fixture: ComponentFixture<EmployeeDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
