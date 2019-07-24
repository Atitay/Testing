using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    [Route("Admin/Exam/{id}")]
    public class ExamController : Controller
    {
        private readonly TestingDbContext _db;

        public ExamController(TestingDbContext db)
        {
            _db = db;
        }

        [Route("Detail")]
        public IActionResult Index(Guid id)
        {
            var _exams = _db.Exams.First(a => a.ExamId == id);

            return View(_exams);
        }

        [Route("AssignQuestions")]
        public IActionResult AssignQuestions(Guid id) => View(_db.Exams.First(a => a.ExamId == id));

        [Route("Questions")]
        public IActionResult Questions(Guid id) => View(_db.Exams.First(a => a.ExamId == id));

        [Route("TestedBy")]
        public IActionResult TestedBy(Guid id) => View(_db.Exams.First(a => a.ExamId == id));

  

        [Route("AddQuestions")]
        [HttpPost]
        public IActionResult AddQuestions(Guid id, string questionsString)
        {
            if(questionsString != null)
            {
              var _exam = _db.Exams.First(a => a.ExamId == id);
            List<Question> questionsList = JsonConvert.DeserializeObject<List<Question>>(questionsString);
                
            _exam.AddQuestionns(questionsList);
            
            _db.SaveChanges(); 
            }
            
            return RedirectToAction("Index","Exam" , new {id = id} );
        }

       

    }
}