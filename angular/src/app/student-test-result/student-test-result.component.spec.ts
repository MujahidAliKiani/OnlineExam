import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentTestResultComponent } from './student-test-result.component';

describe('StudentTestResultComponent', () => {
  let component: StudentTestResultComponent;
  let fixture: ComponentFixture<StudentTestResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentTestResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentTestResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
