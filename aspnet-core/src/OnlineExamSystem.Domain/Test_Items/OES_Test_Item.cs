using OnlineExamSystem.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace OnlineExamSystem.Test_Item
{
   public class OES_Test_Item : AuditedAggregateRoot<Guid>
    {
        public Guid TestId { get; set; }
        public string TestName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Duration { get; set; }

        [ForeignKey("TestId")]
        public OES_Test Test { get; set; }


    }
}
