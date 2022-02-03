using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace OnlineExamSystem.Class
{
  public  class OES_ClassDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
