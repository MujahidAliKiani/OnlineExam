import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestItemComponent } from './test-item.component';

const routes: Routes = [{ path: '', component: TestItemComponent,canActivate: [AuthGuard, PermissionGuard]  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TestItemRoutingModule { }
