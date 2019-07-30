using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public int TotalEarnScore { get; set; }
        public int TotalQuestionScore { get; set; }



        [JsonIgnore]
        public virtual ICollection<UserExamQuestion> UserExamQuestions { get; set; }

        public void UpdateScore()
        {
            TotalEarnScore = UserExamQuestions?.Sum(m => m.EarnScore) ?? 0;
            TotalQuestionScore = UserExamQuestions?.Sum(m => m.QuestionScore) ?? 0;
        }


        public void StartExam()
        {
            if (UserExamQuestions.Count > 0)
                return;

            Exam.QuestionExams.ToList().ForEach(e =>
            {
                var userquestionexam = new UserExamQuestion()
                {
                    UserExamQuestionId = Guid.NewGuid(),
                    QuestionId = e.QuestionId,
                    QuestionScore = e.Question.Point,
                    UserExamId = this.UserExamId,
                };

                UserExamQuestions.Add(userquestionexam);

            });
        }


    }
}
