using OnlineExamSystem.Class;
using OnlineExamSystem.Student;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace OnlineExamSystem.Test
{
   public class OES_TestDto : AuditedEntityDto<Guid>
    {

        public Guid ClassId { get; set; }

        public string TestName { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public int Max_Question { get; set; }

        public Guid? StudentId { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public List<OES_ClassDto> OES_Class { get; set; }

       
        public List<OES_StudentDto> Student { get; set; }

    }
}
