import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/class',
        name: '::Class',
        iconClass: 'fas fa-menu',
        order: 2,
        layout: eLayoutType.application,
        requiredPolicy: 'OnlineExamSystem.Class',
      },
      {
        path: '/test',
        name: '::Test',
        iconClass: 'fas fa-file',
        order: 3,
        layout: eLayoutType.application,
        requiredPolicy: 'OnlineExamSystem.Test',
      },
      
      {
        path: '/student',
        name: '::Student',
        iconClass: '',
        order: 4,
        layout: eLayoutType.application,
        requiredPolicy: 'OnlineExamSystem.Student',
      },
      {
        path: '/test_Result',
        name: '::Result',
        iconClass: '',
        order: 6,
        layout: eLayoutType.application,
        //requiredPolicy: 'OnlineExamSystem.Student',
      }
  
  
    ]);
  };
}
