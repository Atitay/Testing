using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing.FrontEnd.Models.ViewModel
{
    public class QuestionViewModel
    {
        public Question Questions { get; set; }
        public IEnumerable<Topic> Topics { get; set; }
    }
}
