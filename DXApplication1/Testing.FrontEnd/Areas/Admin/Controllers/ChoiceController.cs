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
    public class ChoiceController : Controller
    {
        private readonly TestingDbContext _db;
        public ChoiceController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Choices, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newChoice = new Choice();
            newChoice.QuestionId = _db.Questions.FirstOrDefault().QuestionId;
            newChoice.ChoiceId = new Guid();

            JsonConvert.PopulateObject(values, newChoice);

            _db.Choices.Add(newChoice);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Guid key, string values)
        {
            var _Choice = _db.Choices.First(a => a.QuestionId == key);

            JsonConvert.PopulateObject(values, _Choice);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete(Guid key)
        {
            var _choice = _db.Choices.First(a => a.QuestionId == key);

            _db.Choices.Remove(_choice);
            _db.SaveChanges();
        }

    }
}