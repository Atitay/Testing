using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SubjectsController : Controller
    {
        private readonly TestingDbContext _db;
        public SubjectsController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Subjects, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newSubject = new Subject();
            newSubject.SubjectId = new Guid();

            JsonConvert.PopulateObject(values, newSubject);

            _db.Subjects.Add(newSubject);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Guid key, string values)
        {
            var _subject = _db.Subjects.First(a => a.SubjectId == key);

            JsonConvert.PopulateObject(values, _subject);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete(Guid key)
        {
            var _subject = _db.Subjects.First(a => a.SubjectId == key);

            _db.Subjects.Remove(_subject);
            _db.SaveChanges();
        }


        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Index()
        //{
        //    var lstSubject = _db.Subjects.ToList();
        //    return View(lstSubject);
        //}

        //public IActionResult Create()
        //{

        //    return View();
        //}

        //[HttpPost, ActionName("Create")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreatePost(Subject _subject)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Add(_subject);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(_subject);
        //}


        ////GET Edit Action  Method
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var _subject = await _db.Subjects.FindAsync(id);

        //    if (_subject == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(_subject);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        ////POST Edit Action  Method
        //public async Task<IActionResult> Edit(Guid id, Subject _subject)
        //{
        //    if (id != _subject.SubjectId)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _db.Update(_subject);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(_subject);
        //}

        ////GET Delete Action  Method
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var _subject = await _db.Subjects.FindAsync(id);

        //    if (_subject == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(_subject);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        ////POST Delete Action  Method
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var _subject = await _db.Subjects.FindAsync(id);
        //    _db.Subjects.Remove(_subject);

        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}