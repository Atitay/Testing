using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing.Models
{
    public class UserExam
    {
        [Key]
        public Guid UserExamId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public Guid ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }

    }
}
