using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing.Models
{
    public class UserExamQuestion
    {
        [Key]
        public Guid UserExamQuestionId { get; set; }

        public Guid UserExamId { get; set; }

        [ForeignKey("UserExamId")]
        public virtual UserExam UserExam { get; set; }

        public Guid QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }


        public Guid? SelectChoiceId { get; set; }

        public int EarnScore { get; set; }
        public int QuestionScore { get; set; }

        public int PassingScore { get; set; }

        public bool IsCorrect { get; set; }
        public bool IsCompleted { get; set; }

       
        public void VerifyAnswer ()
        {
            if (SelectChoiceId != null && SelectChoiceId == Question.GetCorrectChoiceId())
            {
                IsCorrect = true;
                EarnScore = QuestionScore;
            }
            else
            {
                IsCorrect = false;
                EarnScore = 0;
            }
        }

    }
}