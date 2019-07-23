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
        public string Role { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserExam> UserExams { get; set; }

    }
}
