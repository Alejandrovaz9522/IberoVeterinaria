import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormPropComponent } from './form-prop.component';

describe('FormPropComponent', () => {
  let component: FormPropComponent;
  let fixture: ComponentFixture<FormPropComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FormPropComponent]
    });
    fixture = TestBed.createComponent(FormPropComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
