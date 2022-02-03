import type { CreateUpdateOES_ClassDto, OES_ClassDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class OES_ClassService {
  apiName = 'Default';

  create = (input: CreateUpdateOES_ClassDto) =>
    this.restService.request<any, OES_ClassDto>({
      method: 'POST',
      url: '/api/app/o-eS_Class',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/o-eS_Class/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, OES_ClassDto>({
      method: 'GET',
      url: `/api/app/o-eS_Class/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<OES_ClassDto>>({
      method: 'GET',
      url: '/api/app/o-eS_Class',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateOES_ClassDto) =>
    this.restService.request<any, OES_ClassDto>({
      method: 'PUT',
      url: `/api/app/o-eS_Class/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
