import type { AuditedEntityDto } from '@abp/ng.core';

export interface OES_ClassDto extends AuditedEntityDto<string> {
  name?: string;
}

export interface CreateUpdateOES_ClassDto {
  name: string;
}
