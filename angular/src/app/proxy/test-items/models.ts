import type { AuditedEntityDto } from '@abp/ng.core';
import type { OES_TestDto } from '../test/models';

export interface CreateUpdateOES_Test_ItemDto {
  testId: string;
  testName?: string;
  question?: string;
  answer?: string;
  duration?: string;
}

export interface OES_Test_ItemDto extends AuditedEntityDto<string> {
  testId?: string;
  testName?: string;
  question?: string;
  answer?: string;
  duration?: string;
  test: OES_TestDto[];
}
