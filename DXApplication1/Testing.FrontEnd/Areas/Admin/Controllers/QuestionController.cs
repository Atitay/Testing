using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly TestingDbContext _db;
        public QuestionController(TestingDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var lstQuestion = _db.Questions.ToList();

            return View(lstQuestion);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost (Question questions)
        {
            if (ModelState.IsValid)
            {
                _db.Questions.Add(questions);
                return RedirectToAction(nameof(Index));
            }
            return View(questions);
        }
    }
}