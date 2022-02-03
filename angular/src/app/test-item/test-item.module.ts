import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TestItemRoutingModule } from './test-item-routing.module';
import { TestItemComponent } from './test-item.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [TestItemComponent],
  imports: [
    CommonModule,
    TestItemRoutingModule,
    SharedModule,
  ]
})
export class TestItemModule { }
