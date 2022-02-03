import type { AuditedEntityDto } from '@abp/ng.core';
import type { OES_ClassDto } from '../class/models';
import type { OES_StudentDto } from '../student/models';

export interface CreateUpdateOES_TestDto {
  classId: string;
  testName?: string;
  date?: string;
  duration?: string;
  max_Question: number;
  studentId: string;
}

export interface OES_TestDto extends AuditedEntityDto<string> {
  classId?: string;
  testName?: string;
  date?: string;
  duration?: string;
  max_Question: number;
  studentId?: string;
  oes_Class: OES_ClassDto[];
  student: OES_StudentDto[];
}
