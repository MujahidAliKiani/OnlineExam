import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { ClassRoutingModule } from './class-routing.module';
import { ClassComponent } from './class.component';


@NgModule({
  declarations: [ClassComponent],
  imports: [
    CommonModule,
    ClassRoutingModule,
    SharedModule
  ]
})
export class ClassModule { }
