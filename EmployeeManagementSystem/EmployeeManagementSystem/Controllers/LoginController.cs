﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeDataUtil.Models;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private HREmployeeManagementContext _context;
        private IUserService _userService;
        
        public LoginController(HREmployeeManagementContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public IActionResult SignIn()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("TestEmployee");
            }
            return View();
        }
        // GET: /<controller>/
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if(ModelState.IsValid)
            {
                Hremployee employee;
                if(await _userService.ValidateCredentials(model.Username, model.Password, out employee))
                {
                    await SignInUser(employee);
                    return RedirectToAction("TestEmployee");
                }
            }
            return View(model);
        }

        public async Task SignInUser(Hremployee employee)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.EmployeeEmail),
                new Claim("EmployeeId", employee.EmployeeId.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", null);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }

        [Authorize]
        public IActionResult TestEmployee()
        {
            return View();
        }

        [Authorize(Policy = "Manager")]
        public IActionResult TestManager()
        {
            return View();
        }

        [Authorize(Policy = "Approver")]
        public IActionResult TestApprover()
        {
            return View();
        }

    }
}
