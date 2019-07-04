using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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


        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Questions, loadOptions);
        }


        [HttpPost]
        public IActionResult Post(string values)
        {
            var newQuestion = new Question();
            newQuestion.QuestionId = new Guid();

            JsonConvert.PopulateObject(values, newQuestion);

            _db.Questions.Add(newQuestion);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Guid key, string values)
        {
            var employee = _db.Questions.First(a => a.QuestionId == key);
            JsonConvert.PopulateObject(values, employee);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete(Guid key)
        {
            var employee = _db.Questions.First(a => a.QuestionId == key);
            _db.Questions.Remove(employee);
            _db.SaveChanges();
        }


        public IActionResult GetQuestions()
        {
            return View();
        }



        public QuestionController(TestingDbContext db)
        {
            _db = db;

            QuestionVM = new QuestionViewModel()
            {
                Topics = _db.Topics.ToList(),
                //Choices = new List<Testing.Models.Choice>(),
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

            _db.Questions.Add(QuestionVM.Questions);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
 //QuestionVM.Choices.QuestionId = QuestionVM.Questions.QuestionId;
            //_db.Choices.Add(QuestionVM.Choices);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuestionVM.Questions = await _db.Questions.Include(m => m.Topic).SingleOrDefaultAsync(m => m.QuestionId == id);
            QuestionVM.Choices = await _db.Choices.FirstOrDefaultAsync(m => m.QuestionId == id);
           

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

                var questionFromDb = _db.Questions.Where(m => m.QuestionId == QuestionVM.Questions.QuestionId).FirstOrDefault();
                var choiceFromDb = _db.Choices.Where(m => m.QuestionId == QuestionVM.Questions.QuestionId).FirstOrDefault();

                questionFromDb.QuestionString = QuestionVM.Questions.QuestionString;
                questionFromDb.Hint = QuestionVM.Questions.Hint;
                questionFromDb.Point = QuestionVM.Questions.Point;
                questionFromDb.QuestionType = QuestionVM.Questions.QuestionType;
                questionFromDb.QuestionLevel = QuestionVM.Questions.QuestionLevel;
                questionFromDb.TopicId = QuestionVM.Questions.TopicId;
                choiceFromDb.ChoiceString = QuestionVM.Choices.ChoiceString;

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
            QuestionVM.Choices = await _db.Choices.FirstOrDefaultAsync(m => m.QuestionId == id);

            if (QuestionVM.Questions == null)
            {
                return NotFound();
            }
            return View(QuestionVM);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        ////POST Delete Action  Method
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var lstQuestion = await _db.Questions.FindAsync(id);

        //    _db.Questions.Remove(lstQuestion);

        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));

        //}


    }
}