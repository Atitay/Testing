using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing
{
    public class Choice
    {
        public Guid ChoiceId
        {
            get => default;
            set
            {
            }
        }

        public string ChoiceString
        {
            get => default;
            set
            {
            }
        }

        public bool isCorrect
        {
            get => default;
            set
            {
            }
        }

        public Guid QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question
        {
            get => default;
            set
            {
            }
        }
    }
}