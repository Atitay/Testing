using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.DAL;

namespace Testing.FrontEnd.Areas.Users.Controllers
{
    [Area("Users")]
    public class ExamsController : Controller
    {
        private readonly TestingDbContext _db;
        public ExamsController(TestingDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}