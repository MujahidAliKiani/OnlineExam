using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineExamSystem.Test_Items
{
   public class CreateUpdateOES_Test_ItemDto
    {
        [Required]
        public Guid TestId { get; set; }
        public string TestName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Duration { get; set; }


    }
}
