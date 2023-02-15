import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VectorCalculationComponent } from './vector-calculation.component';

describe('VectorCalculationComponent', () => {
  let component: VectorCalculationComponent;
  let fixture: ComponentFixture<VectorCalculationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VectorCalculationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VectorCalculationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
