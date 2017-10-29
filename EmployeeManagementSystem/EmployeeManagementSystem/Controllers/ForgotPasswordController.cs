using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Web;
using EmployeeManagementSystem.Services;
using EmployeeDataUtil.Models;
using System.Security.Claims;

namespace EmployeeManagementSystem.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private HREmployeeManagementContext _context;
        private IEmailService _emailService;

        public ForgotPasswordController(HREmployeeManagementContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PasswordRecovery model)
        {
            string email = model.Email.Trim();
            var employee = _context.Hremployee.FirstOrDefault(emp => emp.EmployeeEmail == email && emp.IsActive == true);
            if (employee != null)
            {
                var activerecoverycodes = _context.HrpasswordRecovery.Where(pr => pr.Email == email && pr.IsActive == true).ToList();
                activerecoverycodes.ForEach(pr => pr.IsActive = false);
                _context.HrpasswordRecovery.UpdateRange(activerecoverycodes);
                _context.SaveChanges();
                string guid = System.Guid.NewGuid().ToString(); ;
                HrpasswordRecovery passwordrecovery = new HrpasswordRecovery();
                passwordrecovery.Email = email;
                passwordrecovery.EmployeeId = employee.EmployeeId;
                passwordrecovery.CreatedBy = employee.EmployeeName;
                passwordrecovery.CreatedDateTime = DateTime.Now;
                passwordrecovery.IsActive = true;
                passwordrecovery.LastLogedIn = DateTime.Now;
                passwordrecovery.RecoveryCode = guid;
                passwordrecovery.ModifiedBy = employee.EmployeeName;
                _context.HrpasswordRecovery.Add(passwordrecovery);
                _context.SaveChanges();
                _emailService.PasswordRecoveryEmail(email, guid);
                ViewBag.Success = "An email has been sent to " + email + " to reset the password";
            }
            else
            {
                ViewBag.Error = email + " is not a valid employee email address";
            }
            return View();
        }

        
        public IActionResult RecoverPassword(string id)
        {
            var pr = _context.HrpasswordRecovery.FirstOrDefault(p => p.RecoveryCode == id && p.IsActive == true);
            if(pr == null)
            {
                ViewBag.Error = "The recovery code is no longer valid. Please try forgot password";
            }

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> RecoverPassword([FromBody]ChangePassword model)
        {
            var guid = model.Guid;
            var pr = _context.HrpasswordRecovery.FirstOrDefault(p => p.RecoveryCode == guid && p.IsActive == true);
            var user = _context.Hruser.FirstOrDefault(emp => emp.Email == pr.Email && emp.IsActive == true);
            user.EmployeePassword = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            _context.Hruser.Update(user);
            _context.SaveChanges();
            pr.IsActive = false;
            _context.HrpasswordRecovery.Update(pr);
            _context.SaveChanges();
            return Json(new { success = true });
        }
    }
}