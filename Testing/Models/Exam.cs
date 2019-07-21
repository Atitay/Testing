﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing.Models
{
    public class Exam
    {
        [Key]
        public Guid ExamId { get; set; }

        public string ExamName { get; set; }
        public string Version { get; set; }

        public Guid SubjectId { get; set; }
        [ForeignKey("SubjectId")]

        public virtual Subject Subject { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<QuestionExam> QuestionExams { get; set; }

        public void AddQuestionns(List<Question> questionsList)
        {
            //if null => add new
            if (this.QuestionExams == null)
                this.QuestionExams = new List<QuestionExam>();

            questionsList.ForEach(question =>
            {
            //Need checking list question
           
                    QuestionExam newQuestionExam = new QuestionExam()
                    {
                        QuestionExamId = Guid.NewGuid(),
                        ExamId = this.ExamId,
                        QuestionId = question.QuestionId
                    };
                    QuestionExams.Add(newQuestionExam);
               


            });

        }

    }
}