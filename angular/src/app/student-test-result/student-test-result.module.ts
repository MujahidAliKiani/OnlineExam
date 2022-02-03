import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentTestResultRoutingModule } from './student-test-result-routing.module';
import { StudentTestResultComponent } from './student-test-result.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [StudentTestResultComponent],
  imports: [
    CommonModule,
    StudentTestResultRoutingModule,
    SharedModule
  ]
})
export class StudentTestResultModule { }
