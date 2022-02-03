using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace OnlineExamSystem.Class
{
   public class OES_Class :AuditedAggregateRoot<Guid>
    {
      
        public string Name { get; set; }


    }
}
