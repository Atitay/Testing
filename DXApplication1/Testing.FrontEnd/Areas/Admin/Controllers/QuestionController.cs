using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Testing.DAL;
using Testing.FrontEnd.Models.ViewModel;
using Testing.Models;

namespace Testing.FrontEnd.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly TestingDbContext _db;

        [BindProperty]
        public QuestionViewModel QuestionVM { get; set; }
        public QuestionController(TestingDbContext db)
        {
            _db = db;

            QuestionVM = new QuestionViewModel()
            {
                Topics = _db.Topics.ToList(),             
                Questions = new Testing.Models.Question()
            };
        }

        public async Task<IActionResult> Index()
        {
            var lstQuestion = await _db.Questions.Include(t => t.Topic).ToListAsync();

            return View(lstQuestion);
        }

        public IActionResult Create()
        {

            return View(QuestionVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (ModelState.IsValid)
            {               
                _db.Questions.Add(QuestionVM.Questions);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuestionVM.Questions = await _db.Questions.FindAsync(id);

            if (QuestionVM.Questions == null)
            {
                return NotFound();
            }
            return View(QuestionVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST Edit Action  Method
        public async Task<IActionResult> Edit(Guid id)
        {
            if (ModelState.IsValid)
            {
                var questionFromDb = _db.Questions.Where(m => m.QuestionId ==QuestionVM.Questions.QuestionId).FirstOrDefault();
                
                questionFromDb.QuestionString = QuestionVM.Questions.QuestionString;
                questionFromDb.QuestionType = QuestionVM.Questions.QuestionType;
                questionFromDb.Topic = QuestionVM.Questions.Topic;


                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(QuestionVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuestionVM.Questions = await _db.Questions.FindAsync(id);

        
            if (QuestionVM.Questions == null)
            {
                return NotFound();
            }
            return View(QuestionVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST Delete Action  Method
        public async Task<IActionResult> Delete(Guid id)
        {
            var lstQuestion = await _db.Questions.FindAsync(id);

            _db.Questions.Remove(lstQuestion);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}