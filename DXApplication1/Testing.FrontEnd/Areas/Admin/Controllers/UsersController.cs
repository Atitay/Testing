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

    public class UsersController : Controller
    {
        private readonly TestingDbContext _db;
        public UsersController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Users, loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var newUser = new User
            {
                UserId = new Guid()
            };

            JsonConvert.PopulateObject(values, newUser);

            _db.Users.Add(newUser);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Guid key, string values)
        {
            var _user = _db.Users.First(a => a.UserId == key);

            JsonConvert.PopulateObject(values, _user);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public void Delete(Guid key)
        {
            var _user = _db.Users.First(a => a.UserId == key);

            _db.Users.Remove(_user);
            _db.SaveChanges();
        }


        public IActionResult Index()
        {
            return View();
        }

        
    }
}