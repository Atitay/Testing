using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Testing.Models
{
    public class User 
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserExam> UserExams { get; set; }

        public void AddExams(List<Exam> examsList)
        {
            //if null => add new
            if (this.UserExams == null)
                this.UserExams = new List<UserExam>();

            examsList.ForEach(exam =>
            {
                //Need checking list question
                UserExam newUserExam = new UserExam()

                {
                    UserExamId = Guid.NewGuid(),
                    UserId = this.UserId,
                    ExamId = exam.ExamId,
                                        
                };

                UserExams.Add(newUserExam);

            });

        }


    }
}
