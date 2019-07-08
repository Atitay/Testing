using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Testing.Models
{
    public class Topic
    {
        [Key]

        [Display(Name = ("Topic Name"))]
        public Guid TopicId { get; set; }

        public Guid? ParentId { get; set; }
        public Guid? ChildId { get; set; }

        [Display(Name =("Topic Name"))]
        public string TopicName { get; set; }
    }
}