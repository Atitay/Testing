using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Testing.DAL;

namespace Testing.FrontEnd.Areas.Users.Controllers
{
    [Area("Users")]

    public class HomeController : Controller
    {
        private readonly TestingDbContext _db;
        protected Guid CurrentUserId => Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public HomeController(TestingDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

       
    }
}