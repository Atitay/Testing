using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExamController : Controller
    {
        private readonly TestingDbContext _db;

        public ExamController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index(Guid id)
        {
            var _exams = _db.Exams.First(a => a.ExamId == id);

            return View(_exams);
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPost(Guid id,Exam exam,Question question)
        {
            var _exams = _db.Exams.First(a => a.ExamId == id);
            _exams.ExamName = exam.ExamName;
            _exams.Version = exam.Version;
            _exams.SubjectId = exam.SubjectId;
            _exams.StartDate = exam.StartDate;
            _exams.EndDate = exam.EndDate;

          
            _db.SaveChanges();
            return RedirectToAction("Index", "Exams");
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            //return DataSourceLoader.Load(_db.QuestionExams.Where(m => m.ExamId == id), loadOptions);
           return DataSourceLoader.Load(_db.Exams, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newQuestionExam = new QuestionExam
            {
                QuestionExamId = new Guid()
            };

            JsonConvert.PopulateObject(values, newQuestionExam);

            _db.QuestionExams.Add(newQuestionExam);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Guid key, string values)
        {
            var _exam = _db.QuestionExams.First(a => a.ExamId == key);

            JsonConvert.PopulateObject(values, _exam);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete(Guid key)
        {
            var _exam = _db.QuestionExams.First(a => a.ExamId == key);

            _db.QuestionExams.Remove(_exam);
            _db.SaveChanges();
        }


        public IActionResult GetQuestions(Guid id)
        {
            var _question = _db.QuestionExams.First(a => a.ExamId == id);

            return View(_question);
        }

      
    }
}