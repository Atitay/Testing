using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Testing.Models
{
    public class Topic
    {
        [Key]    
        public Guid TopicId { get; set; }

       
        public Guid? ParentId { get; set; }
        [ForeignKey("ParentId")]
        [JsonIgnore]
        public virtual Topic Parent { get; set; }

        [JsonIgnore]
        public virtual ICollection<Topic> Childs { get; set; }

        [Display(Name =("Topic Name"))]
        public string TopicName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; }
    }
}