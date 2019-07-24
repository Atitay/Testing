using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Testing.DAL;

namespace Testing.FrontEnd.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles =("Users"))]
    public class ExamsController : Controller
    {
        private readonly TestingDbContext _db;
        public ExamsController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Exams, loadOptions);
        }

        [HttpGet]
        public object GetUserExam(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.UserExams, loadOptions);
        }

        [HttpGet]
        public object GetSubject(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Subjects, loadOptions);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AssignExams()
        {
            return View();
        }


    }
}