using OnlineExamSystem.Class;
using OnlineExamSystem.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace OnlineExamSystem.Test
{
   public class OES_Test : AuditedAggregateRoot<Guid>
    {

        public Guid ClassId { get; set; }
        public string TestName { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public int Max_Question { get; set; }

        public Guid? StudentId { get; set; }

        public Guid? TemplateId { get; set; }


        [ForeignKey("StudentId")]
        public OES_Student Student { get; set; }

        [ForeignKey("ClassId")]
        public  OES_Class OES_Class { get; set; }
    }
}
