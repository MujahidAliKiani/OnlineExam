using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamSystem.Test_Items
{
  public  class CreateStudentTestDto
    {
        public Guid StudentId { get; set; }
        public Guid TestId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Duration { get; set; }






    }
}
