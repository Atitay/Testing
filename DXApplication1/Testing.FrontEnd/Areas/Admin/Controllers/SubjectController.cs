using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        private readonly TestingDbContext _db;
        public SubjectController(TestingDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var lstSubject = _db.Subjects.ToList();
            return View(lstSubject);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Subject _subject)
        {
            if (ModelState.IsValid)
            {
                _db.Add(_subject);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_subject);
        }


        //GET Edit Action  Method
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _subject = await _db.Subjects.FindAsync(id);

            if (_subject == null)
            {
                return NotFound();
            }

            return View(_subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST Edit Action  Method
        public async Task<IActionResult> Edit(Guid id, Subject _subject)
        {
            if (id != _subject.SubjectId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(_subject);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_subject);
        }

        //GET Delete Action  Method
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _subject = await _db.Subjects.FindAsync(id);

            if (_subject == null)
            {
                return NotFound();
            }

            return View(_subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST Delete Action  Method
        public async Task<IActionResult> Delete(Guid id)
        {
            var _subject = await _db.Subjects.FindAsync(id);
            _db.Subjects.Remove(_subject);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}