using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.DAL;

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
        public IActionResult Index()
        {
            var lstExam = _db.Exams.ToList();
            return View(lstExam);
        }
    }
}