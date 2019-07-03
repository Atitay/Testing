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
    public class TopicController : Controller
    {
        private readonly TestingDbContext _db;
        public TopicController(TestingDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var lstTopic = _db.Topics.ToList();
            return View(lstTopic);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Topic _topic)
        {
            if (ModelState.IsValid)
            {
                _db.Add(_topic);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_topic);
        }


        //GET Edit Action  Method
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _topic = await _db.Topics.FindAsync(id);

            if (_topic == null)
            {
                return NotFound();
            }

            return View(_topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST Edit Action  Method
        public async Task<IActionResult> Edit(Guid id, Topic _topic)
        {
            if (id != _topic.TopicId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(_topic);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_topic);
        }

        //GET Delete Action  Method
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _topic = await _db.Topics.FindAsync(id);

            if (_topic == null)
            {
                return NotFound();
            }

            return View(_topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST Delete Action  Method
        public async Task<IActionResult> Delete(Guid id)
        {
            var _topic = await _db.Topics.FindAsync(id);
            _db.Topics.Remove(_topic);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}