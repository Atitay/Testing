using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid QuestionId { get; set; }


        //public Question()
        //{
        //    Choices = new List<Choice>();
        //}

        [Display(Name = ("Question"))]
        public string QuestionString { get; set; }
        public string Hint { get; set; }
        public int Point { get; set; }


        public Guid? TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        [Display(Name = ("Question Type"))]
        public QuestionType QuestionType { get; set; }

        [Display(Name = ("Question Level"))]
        public QuestionLevel QuestionLevel { get; set; }


        public virtual ICollection<Choice> Choices { get; set; }
    }
}