import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentTestRoutingModule } from './student-test-routing.module';
import { StudentTestComponent } from './student-test.component';
import { SharedModule } from '../shared/shared.module';
import { CdTimerModule } from 'angular-cd-timer';

@NgModule({
  declarations: [StudentTestComponent],
  imports: [
    CommonModule,
    CdTimerModule,
    StudentTestRoutingModule,
    SharedModule,

  ]
})
export class StudentTestModule { }
