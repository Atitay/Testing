using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Areas.Users.Controllers
{
    [Area("Users")]

    public class ExamsController : Controller
    {
        private readonly TestingDbContext _db;
        protected Guid CurrentUserId => Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
       
        public ExamsController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Exams, loadOptions);
        }

        [HttpGet]
        public object GetUserExam(DataSourceLoadOptions loadOptions)
        {
            var userExam = _db.UserExams.Where(u => u.UserId == CurrentUserId);
            return DataSourceLoader.Load(userExam, loadOptions);
        }


        [HttpGet]
        public object GetSubject(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Subjects, loadOptions);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Result()
        {
            return View();
        }

        public IActionResult AssignExams()
        {
            return View();
        }

        //[HttpDelete]
        //public void DeleteUserExam(Guid key)
        //{
        //    var userExam = _db.UserExams.First(a => a.ExamId == key);

        //    _db.UserExams.Remove(userExam);
        //    _db.SaveChanges();
        //}

        [HttpPost]
        public IActionResult AddExams(string ExamName)
        {
            if (ExamName != null)
            {
                var _user = _db.Users.First(a => a.UserId == CurrentUserId);
                List<Exam> examsList = JsonConvert.DeserializeObject<List<Exam>>(ExamName);
                
                _user.AddExams(examsList);

                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Exams");
        }
        
    }
}