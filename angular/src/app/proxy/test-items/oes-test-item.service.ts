import type { CreateUpdateOES_Test_ItemDto, OES_Test_ItemDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root',
})
export class OES_Test_ItemService {
  apiName = 'Default';

  create = (input: CreateUpdateOES_Test_ItemDto) =>
    this.restService.request<any, OES_Test_ItemDto>({
      method: 'POST',
      url: '/api/app/o-eS_Test_Item',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/o-eS_Test_Item/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, OES_Test_ItemDto>({
      method: 'GET',
      url: `/api/app/o-eS_Test_Item/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<OES_Test_ItemDto>>({
      method: 'GET',
      url: '/api/app/o-eS_Test_Item',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });
    getSelectedList = (id: string) =>
    this.restService.request<any, PagedResultDto<OES_Test_ItemDto>>({
      method: 'GET',
      url: `/api/app/o-eS_Test_Item/${id}/selected-list`,
      
       
    },
    { apiName: this.apiName });
    getStudentTestList = (id:string) =>
    this.restService.request<any, OES_Test_ItemDto>({
      method: 'GET',
      url: `/api/app/o-eS_Test_Item/${id}/student-test-list`,
      
    },
    { apiName: this.apiName });
    updateStudentAnswer = (id:string, answer:string) =>
    this.restService.request<any, OES_Test_ItemDto>({
      method: 'POST',
      url: `/api/app/o-eS_Test_Item/${id}/update-student-answer?answer=`+answer,
    },
    { apiName: this.apiName });
  update = (id: string, input: CreateUpdateOES_Test_ItemDto) =>
    this.restService.request<any, OES_Test_ItemDto>({
      method: 'PUT',
      url: `/api/app/o-eS_Test_Item/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
