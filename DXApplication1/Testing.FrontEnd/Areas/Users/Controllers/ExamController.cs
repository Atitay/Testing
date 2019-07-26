using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Areas.Users.Controllers
{
    [Area("Users")]
    public class ExamController : Controller
    {
        private readonly TestingDbContext _db;
        protected Guid CurrentUserId => Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public ExamController(TestingDbContext db)
        {
            _db = db;
        }

        public IActionResult Detail(Guid id)
        {
            var _exams = _db.UserExams.First(a => a.ExamId == id);
            return View(_exams);
        }

        public IActionResult QuestionAnswer(Guid id)
        {
            var _exams = _db.QuestionExams.First(a => a.QuestionId == id);
            return View(_exams);
        }


        [HttpGet]
        public object GetExamQuestion(DataSourceLoadOptions loadOptions, Guid id)
        {
            return DataSourceLoader.Load(_db.QuestionExams.Where(m => m.ExamId == id), loadOptions);
        }

        [HttpGet]
        public object GetChoice(DataSourceLoadOptions loadOptions, Guid id)
        {
            return DataSourceLoader.Load(_db.Choices.Where(u => u.QuestionId == id), loadOptions);
        }

        [HttpGet]
        public IActionResult Test(Guid id)
        {
            var _UserExas = _db.UserExams.First(a => a.ExamId == id);
            _UserExas.StartExam();

            _db.SaveChanges();
            return View(_UserExas);
        }

        [HttpPost, ActionName("Test")]
        public IActionResult TestPost(Guid id,Guid questionAnswer)
        {
         
            var _questionAnswer = _db.UserExamQuestions.First(a => a.UserExam.ExamId == id);
             _questionAnswer.SelectChoiceId = questionAnswer;

            _db.SaveChanges();

            return RedirectToAction("Test");
        }

     

    }
}