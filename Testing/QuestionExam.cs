using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing
{
    public class QuestionExam
    {

        public Guid QuestionExamId { get; set; }
        public Guid QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question
        {
            get => default;
            set
            {
            }
        }


        public Guid ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exam Exam
        {
            get => default;
            set
            {
            }
        }
    }
}