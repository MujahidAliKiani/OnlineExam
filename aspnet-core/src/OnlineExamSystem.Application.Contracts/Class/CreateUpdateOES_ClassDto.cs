using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineExamSystem.Class
{
    public class CreateUpdateOES_ClassDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
