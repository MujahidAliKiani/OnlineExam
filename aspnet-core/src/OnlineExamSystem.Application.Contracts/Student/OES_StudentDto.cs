using OnlineExamSystem.Class;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace OnlineExamSystem.Student
{
   public class OES_StudentDto : AuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ClassId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int RegistriationNumber { get; set; }
      
        public List<OES_ClassDto> Class { get; set; }

    }
}
