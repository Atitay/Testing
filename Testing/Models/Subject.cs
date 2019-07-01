using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.Models
{
    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

        public SubjectLevel SubjectLevel { get; set; }
    }
}