import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'OnlineExamSystem',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44346',
    redirectUri: baseUrl,
    clientId: 'OnlineExamSystem_App',
    responseType: 'code',
    scope: 'offline_access openid profile role email phone OnlineExamSystem',
  },
  apis: {
    default: {
      url: 'https://localhost:44346',
      rootNamespace: 'OnlineExamSystem',
    },
  },
} as Environment;
