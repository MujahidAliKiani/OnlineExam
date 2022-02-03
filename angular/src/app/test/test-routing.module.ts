import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './test.component';
import { AuthGuard, PermissionGuard } from '@abp/ng.core';
const routes: Routes = [{ path: '', component: TestComponent,canActivate: [AuthGuard, PermissionGuard]  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
  
})
export class TestRoutingModule { }
