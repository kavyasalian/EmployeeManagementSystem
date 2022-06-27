import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarfooterComponent } from './sidebarfooter.component';

describe('SidebarfooterComponent', () => {
  let component: SidebarfooterComponent;
  let fixture: ComponentFixture<SidebarfooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SidebarfooterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SidebarfooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
