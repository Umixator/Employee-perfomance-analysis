using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using EPA.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using EPA.Services;

namespace HotDeskApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _service;
        private readonly EpaDbContext _context;
        public UserController(EpaDbContext context, UserService service)
        {
            _context = context;
            _service = service;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect login or(and) password");
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public IActionResult UserTable()
        {
            UserTable ut = new UserTable();
            ut.Users = _service.GetUserList();
            ut.Departments = _service.GetDepartmentList();
            return View(ut);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _service.DeleteUser(Id);
            return RedirectToAction("UserTable");
        }
        public IActionResult Create()
        {
            UserTable ut = new UserTable();
            ut.Departments = _service.GetDepartmentList();
            ut.Users = _service.GetUserList();
            return View(ut);
        }
        public IActionResult Update(int Id)
        {
            UserTable ut = new UserTable();
            ut.Departments = _service.GetDepartmentList();
            ut.Users = _service.GetUserList();
            ut.User = _service.FindUser(Id);
            return View(ut);
        }
        [HttpPost]
        public async Task <IActionResult> Create(UserTable u)
        {
            await _service.CreateUser(u.User);
            return RedirectToAction("UserTable");
        }
        [HttpGet]
        public async Task <IActionResult> Exit()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task <IActionResult> Update(UserTable u)
        {
            await _service.UpdateUser(u);
            return RedirectToAction("UserTable");
        }
    }
}

