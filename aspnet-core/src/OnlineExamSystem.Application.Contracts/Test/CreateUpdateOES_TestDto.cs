using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineExamSystem.Test
{
  public  class CreateUpdateOES_TestDto
    {
       
        public Guid ClassId { get; set; }

        public string TestName { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public int Max_Question { get; set; }
    
        public Guid? StudentId { get; set; }


    }
}
