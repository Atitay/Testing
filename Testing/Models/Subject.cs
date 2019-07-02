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

        public string SubjectName { get; set; }
        public SubjectLevel SubjectLevel { get; set; }
    }
}