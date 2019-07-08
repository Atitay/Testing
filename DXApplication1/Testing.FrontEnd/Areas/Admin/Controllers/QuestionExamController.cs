using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionExamController : Controller
    {
        private readonly TestingDbContext _db;
        public QuestionExamController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.QuestionExams, loadOptions);
        }
        public object GetQuestion(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Questions, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newQuesExam = new QuestionExam();
            newQuesExam.QuestionExamId = new Guid();

            JsonConvert.PopulateObject(values, newQuesExam);

            _db.QuestionExams.Add(newQuesExam);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Guid key, string values)
        {
            var _quesexam = _db.QuestionExams.First(a => a.QuestionExamId == key);

            JsonConvert.PopulateObject(values, _quesexam);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete(Guid key)
        {
            var _quesexam = _db.QuestionExams.First(a => a.QuestionExamId == key);

            _db.QuestionExams.Remove(_quesexam);
            _db.SaveChanges();
        }


        public IActionResult GetQuestionExams()
        {
            return View();
        }
    }
}