using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing.Models
{
    public class Exam
    {
        public Guid ExamId { get; set; }
        public string ExamName { get; set; }
        public string Version { get; set; }

        public Guid SubjectId { get; set; }
        [ForeignKey("SubjectId")]

        public virtual Subject Subject { get; set; }
    }
}