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
        public class TopicsController : Controller
        {
            private readonly TestingDbContext _db;
            public TopicsController(TestingDbContext db)
            {
                _db = db;
            }

            [HttpGet]
            public object Get(DataSourceLoadOptions loadOptions)
            {
                return DataSourceLoader.Load(_db.Topics, loadOptions);
            }

            [HttpPut]
            public IActionResult Put(Guid key, string values)
            {
                var _topic = _db.Topics.First(a => a.TopicId == key);

                JsonConvert.PopulateObject(values, _topic);

                _db.SaveChanges();

                return Ok();
            }


            public IActionResult Index()
            {
                return View();
            }

        
    }
}