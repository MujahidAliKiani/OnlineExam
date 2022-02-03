using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineExamSystem.Student
{
  public  class CreateUpdateOES_StudentDto
    {
     
        [Required]
        public Guid ClassId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int RegistriationNumber { get; set; }

      
    }
}
