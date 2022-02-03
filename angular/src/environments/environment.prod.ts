import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
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
    scope: 'offline_access OnlineExamSystem',
  },
  apis: {
    default: {
      url: 'https://localhost:44346',
      rootNamespace: 'OnlineExamSystem',
    },
  },
} as Environment;
