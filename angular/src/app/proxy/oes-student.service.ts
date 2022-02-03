import type { CreateUpdateOES_StudentDto, OES_StudentDto } from './student/models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class OES_StudentService {
  apiName = 'Default';

  create = (input: CreateUpdateOES_StudentDto) =>
    this.restService.request<any, OES_StudentDto>({
      method: 'POST',
      url: '/api/app/o-eS_Student',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/o-eS_Student/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, OES_StudentDto>({
      method: 'GET',
      url: `/api/app/o-eS_Student/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<OES_StudentDto>>({
      method: 'GET',
      url: '/api/app/o-eS_Student',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });

  update = (id: string, input: CreateUpdateOES_StudentDto) =>
    this.restService.request<any, OES_StudentDto>({
      method: 'PUT',
      url: `/api/app/o-eS_Student/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
