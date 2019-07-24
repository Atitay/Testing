using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;
using Testing.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Testing.FrontEnd.Areas.Authen.Models;

namespace Testing.FrontEnd.Areas.Authen.Controllers
{
    [Area("Authen")]

    public class AuthenController : Controller
    {
        private readonly TestingDbContext _db;
        public AuthenController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost, ActionName("SignIn")]
        public async Task<IActionResult> SignInPost(LoginViewModel model)
        {
            var userlogin = _db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();

            if (userlogin != null)
            {
                await ProcessSignIn(userlogin);

                if (userlogin.isAdmin)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "Users" });
                }

            }
            else
            {
                return Content("SignIn not Complete");
            }

        }


        private async Task ProcessSignIn(User user)
        {
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,user.UserName ),
                     new Claim(ClaimTypes.Email,user.Email),
                      new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                };

            if (user.isAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "Users"));
            }


            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //log in expire 1 min
                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1),

                //true, alway login although close/open it
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("SignIn");

        }


        [HttpGet]
        public IActionResult Register()
        {
            var register = new LoginViewModel();

            return View(register);
        }

        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessRegister(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CheckPassword)
                {
                    var newUser = new User()
                    {
                        UserId = new Guid(),
                        Email = model.Email,
                        UserName = model.UserName,
                        Password = model.Password
                    };
                    _db.Users.Add(newUser);
                    _db.SaveChanges();
                }

                return RedirectToAction("SignIn");
            }

            return RedirectToAction("Register");

        }
    }
}