import { ABP } from '@abp/ng.core';
import { eThemeSharedRouteNames } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestModule } from './test/test.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  { path: 'student_Test/:id', loadChildren: () => import('./student-test/student-test.module').then(m => m.StudentTestModule) },
  { path: 'test_Result', loadChildren: () => import('./student-test-result/student-test-result.module').then(m => m.StudentTestResultModule) },
  { path: 'class', loadChildren: () => import('./class/class.module').then(m => m.ClassModule) },
  { path: 'test', loadChildren: () => import('./test/test.module').then(m => m.TestModule) },
  { path: 'test_Item/:id', loadChildren: () => import('./test-item/test-item.module').then(m => m.TestItemModule) },
  { path: 'student', loadChildren: () => import('./student/student.module').then(m => m.StudentModule) },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'Class',
    loadChildren: () =>
    import('./class/class.module').then(m => m.ClassModule),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  { path: 'Class', loadChildren: () => import('./class/class.module').then(m => m.ClassModule) },
  
  { path: 'Test', loadChildren: () => import('./test/test.module').then(m => m.TestModule) },
  { path: 'TestItem', loadChildren: () => import('./test-item/test-item.module').then(m => m.TestItemModule) },
  { path: 'StudentTest', loadChildren: () => import('./student-test/student-test.module').then(m => m.StudentTestModule) },
  { path: 'Student', loadChildren: () => import('./student/student.module').then(m => m.StudentModule) },
  { path: 'StudentTestResult', loadChildren: () => import('./student-test-result/student-test-result.module').then(m => m.StudentTestResultModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
