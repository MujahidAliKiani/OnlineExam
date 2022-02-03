using Abp.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using OnlineExamSystem.Class;
using OnlineExamSystem.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace OnlineExamSystem.Student
{
   public class OES_Student : AuditedAggregateRoot<Guid>
    {
       
        public Guid ClassId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact  { get; set; }
        public string Address { get; set; }
        public int RegistriationNumber { get; set; }
        public Guid UserId { get;  set; }

        [ForeignKey("ClassId")]
        public OES_Class OES_Class { get; set; }
     

    }
}
