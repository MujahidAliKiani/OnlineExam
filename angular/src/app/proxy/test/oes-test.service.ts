import type { CreateUpdateOES_TestDto, OES_TestDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import { OES_Test_ItemDto } from '@proxy/test-items';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class OES_TestService {
  apiName = 'Default';

  create = (input: CreateUpdateOES_TestDto) =>
    this.restService.request<any, OES_TestDto>({
      method: 'POST',
      url: '/api/app/o-eS_Test',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/o-eS_Test/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, OES_TestDto>({
      method: 'GET',
      url: `/api/app/o-eS_Test/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<OES_TestDto>>({
      method: 'GET',
      url: '/api/app/o-eS_Test',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });
    getResultList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<OES_TestDto>>({
      method: 'GET',
      url: '/api/app/o-eS_Test/result-list',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });
    
    getStudentTestList = (id:string) =>
    this.restService.request<any, OES_Test_ItemDto>({
      method: 'POST',
      url: `/api/app/o-eS_Test/${id}/student-test`,
      
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateOES_TestDto) =>
    this.restService.request<any, OES_TestDto>({
      method: 'PUT',
      url: `/api/app/o-eS_Test/${id}`,
      body: input,
    },
    { apiName: this.apiName });

    downloadResult = (id: string) =>
    this.restService.request<any, Blob>({
      method: 'POST',
      url: `/api/app/o-eS_Test/${id}/download-result`,
      responseType: 'blob'
    
    
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
