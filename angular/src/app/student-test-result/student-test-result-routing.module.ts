import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentTestResultComponent } from './student-test-result.component';

const routes: Routes = [{ path: '', component: StudentTestResultComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentTestResultRoutingModule { }
