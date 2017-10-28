using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeDataUtil.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using EmployeeManagementSystem.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementSystem.Controllers
{
    public class ApprovedPretravelClaimController : Controller
    {
        private HREmployeeManagementContext _context;

        public ApprovedPretravelClaimController(HREmployeeManagementContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            var employee = _context.Hremployee.FirstOrDefault(emp => emp.EmployeeEmail == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var model = _context.HrtravelClaim.Where(claim => claim.EmployeeId == employee.EmployeeId && claim.IsActive == true && claim.Status.StatusName == "APPROVED").ToList();
            return View(model);
        }

        [Authorize]
        public IActionResult AddExpense(int id)
        {

            CreateExpenseModel model = new CreateExpenseModel();
            model.CategoryList = _context.HrexpenseCategory.ToList();
            model.SelectedTravelClaim = _context.HrtravelClaim.Find(id);
            model.SubCategoryList = _context.HrexpenseSubCategory.ToList();
            model.CurrencyList = _context.Hrcurrency.ToList();
            var employee = _context.Hremployee.FirstOrDefault(emp => emp.EmployeeEmail == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            model.Expenses = _context.Hrexpenses.Where(exp => exp.Claim.Employee.EmployeeEmail == employee.EmployeeEmail && exp.ClaimId == id && exp.Claim.IsActive == true).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddExpense(SubmitExpense model)
        {
            var employee = _context.Hremployee.FirstOrDefault(emp => emp.EmployeeEmail == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Hrexpenses expenses = new Hrexpenses();
            expenses.ClaimId = model.ClaimId;
            expenses.ExpenseAmount = model.ExpenseAmount;
            expenses.ExpenseCategory = model.ExpenseCategory;
            expenses.ExpenseStartDate = model.ExpenseStartDate;
            expenses.ExpenseEndDate = model.ExpenseEndDate;
            expenses.ExpenseSubCategory = model.ExpenseSubCategory;
            expenses.ModifiedBy = employee.EmployeeName;
            expenses.ModifiedDate = DateTime.Now;
            expenses.CurrencyId = model.CurrencyId;
            _context.Hrexpenses.Add(expenses);
            _context.SaveChanges();
            if (model.Attachment.Length > 0)
            {
                string fileName = model.Attachment.FileName;
                string filePath = "wwwroot\\Files\\";
                using (var stream = new FileStream(filePath + fileName, FileMode.Create))
                {
                    model.Attachment.CopyTo(stream);
                    HrexpensesAttachments attachment = new HrexpensesAttachments();
                    attachment.FilePath = filePath;
                    attachment.ExpenseFileName = fileName;
                    attachment.Expense = expenses;
                    _context.HrexpensesAttachments.Add(attachment);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("AddExpense");
        }
    }
}
