using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.Models
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public string QuestionString { get; set; }

        public string Hint { get; set; }

        public Topic Topic { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}