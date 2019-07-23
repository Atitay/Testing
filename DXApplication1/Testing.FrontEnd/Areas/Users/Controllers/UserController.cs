using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.DAL;

namespace Testing.FrontEnd.Areas.Users.Controllers
{
    [Area("Users")]
    public class UserController : Controller
    {
        private readonly TestingDbContext _db;
        public UserController(TestingDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}