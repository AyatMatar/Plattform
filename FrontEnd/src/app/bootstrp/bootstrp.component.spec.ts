import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BootstrpComponent } from './bootstrp.component';

describe('BootstrpComponent', () => {
  let component: BootstrpComponent;
  let fixture: ComponentFixture<BootstrpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BootstrpComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BootstrpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
