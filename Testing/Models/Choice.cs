using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing.Models
{
    public class Choice
    {
        [Key]
        public Guid ChoiceId { get; set; }  
        
        [Display(Name = "Choice")]
        public string ChoiceString { get; set; }
        public bool isCorrect { get; set; }

        public Guid QuestionId { get; set; }
        [ForeignKey("QuestionId")]

        public virtual Question Questions { get; set; }


    }

    
}