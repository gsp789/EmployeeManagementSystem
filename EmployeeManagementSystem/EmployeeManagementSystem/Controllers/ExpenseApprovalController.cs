using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeDataUtil.Models;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Controllers
{
    public class ExpenseApprovalController : Controller
    {
        private HREmployeeManagementContext _context;

        public ExpenseApprovalController(HREmployeeManagementContext context)
        {
            _context = context;
        }
        public IActionResult Index(int claimId)
        {

            var ExpensesList = from exp in _context.Hrexpenses
                               where exp.ClaimId == claimId
                               select exp;
            if(ExpensesList.Any())
            {
                List<ExpenseApproval> expenses = new List<ExpenseApproval>();
                foreach(var exp in ExpensesList)
                {
                    var temp = new ExpenseApproval();
                    //temp.Category = exp.Cate
                }
            }
            return View();
        }
    }
}