using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing
{
    public class Exam
    {
        public string ExamName
        {
            get => default;
            set
            {
            }
        }

        public int ExamId
        {
            get => default;
            set
            {
            }
        }

        public string Version
        {
            get => default;
            set
            {
            }
        }

        public Guid SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject
        {
            get => default;
            set
            {
            }
        }
    }
}