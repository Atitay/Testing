using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Testing.DAL;

namespace Testing.FrontEnd.Areas.Users.Controllers
{
    [Area("Users")]
    public class ExamController : Controller
    {
        private readonly TestingDbContext _db;
        public ExamController(TestingDbContext db)
        {
            _db = db;
        }
        public IActionResult Detail(Guid id)
        {
            var _exams = _db.Exams.First(a => a.ExamId == id);
            return View(_exams);
        }

        public IActionResult Test(Guid id)
        {
            var _exams = _db.Exams.First(a => a.ExamId == id);
            return View(_exams);
        }

        [HttpGet]
        public object GetChoice(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Choices.Where(u=>u.QuestionId == ), loadOptions);
        }


    }
}