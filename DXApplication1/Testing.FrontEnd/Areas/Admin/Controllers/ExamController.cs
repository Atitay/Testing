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
    public class ExamController : Controller
    {
        private readonly TestingDbContext _db;
        public ExamController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Exams, loadOptions);
        }

        [HttpGet]
        public object GetSubject(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Subjects, loadOptions);
        }

        [HttpGet]
        public object GetChoice(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Choices, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newExam = new Exam ();
            newExam.ExamId = new Guid();

            JsonConvert.PopulateObject(values, newExam);

            _db.Exams.Add(newExam);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Guid key, string values)
        {
            var _exam = _db.Exams.First(a => a.ExamId == key);

            JsonConvert.PopulateObject(values, _exam);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete(Guid key)
        {
            var _exam = _db.Exams.First(a => a.ExamId == key);

            _db.Exams.Remove(_exam);
            _db.SaveChanges();
        }


        public IActionResult GetExams()
        {
            return View();
        }


        public IActionResult GetQuestionExams()
        {
            return View();
        }

    }
}