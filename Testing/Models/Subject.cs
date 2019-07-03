using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Testing.Models
{
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; }

        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; }

        [Display(Name = "Subject Level")]
        public SubjectLevel SubjectLevel { get; set; }
    }
}