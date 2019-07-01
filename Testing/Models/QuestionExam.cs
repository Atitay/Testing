using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing.Models
{
    public class QuestionExam
    {

        public Guid QuestionExamId { get; set; }
        public Guid QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }


        public Guid ExamId { get; set; }
        [ForeignKey("ExamId")]

        public virtual Exam Exam { get; set; }
    }
}