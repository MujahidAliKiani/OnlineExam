import type { AuditedEntityDto } from '@abp/ng.core';
import type { OES_ClassDto } from '../class/models';

export interface CreateUpdateOES_StudentDto {
  userId: string;
  classId: string;
  firstName?: string;
  lastName?: string;
  email?: string;
  contact?: string;
  address?: string;
  registriationNumber: number;
}

export interface OES_StudentDto extends AuditedEntityDto<string> {
  userId?: string;
  classId?: string;
  firstName?: string;
  lastName?: string;
  email?: string;
  contact?: string;
  address?: string;
  registriationNumber: number;
  class: OES_ClassDto[];
}
