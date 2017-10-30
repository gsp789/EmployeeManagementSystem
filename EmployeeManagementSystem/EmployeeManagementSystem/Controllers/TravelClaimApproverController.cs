using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeDataUtil.Models;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Controllers
{
    public class TravelClaimApproverController : Controller
    {
        private HREmployeeManagementContext _context;
        public TravelClaimApproverController(HREmployeeManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index(int claimId)
        {
            TravelClaimRequestApprovalModel model = new TravelClaimRequestApprovalModel();
            var tempClaim = from claim in _context.HrtravelClaim
                            where claim.ClaimId == claimId
                            select claim;
            if(tempClaim.Any())
            {
                var temp = tempClaim.First();
                model.TravelClaimId = temp.ClaimId;
                model.StartDate = temp.StartDate.Value.Date;
                model.EndDate = temp.EndTime.Value.Date;
                model.Purpose = temp.BusinessPurpose;
                model.EmployeeId = temp.EmployeeId.Value;
                var employee = from emp in _context.Hremployee
                               where emp.EmployeeId == temp.EmployeeId.Value
                               select emp;
                if(employee.Any())
                {
                    model.EmployeeName = employee.First().EmployeeName;

                }
            }
            else
            {
                return null;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(ClaimApproveDecisionModel model)
        {

            return View();
        }
    }
}