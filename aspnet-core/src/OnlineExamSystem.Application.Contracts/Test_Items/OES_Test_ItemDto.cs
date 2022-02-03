using OnlineExamSystem.Test;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace OnlineExamSystem.Test_Items
{
   public class OES_Test_ItemDto : AuditedEntityDto<Guid>
    {
        public Guid TestId { get; set; }
        public string TestName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Duration { get; set; }

        public List<OES_TestDto> Test { get; set; }



    }
}
