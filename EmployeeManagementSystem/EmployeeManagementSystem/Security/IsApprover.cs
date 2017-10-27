using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using EmployeeDataUtil.Models;

namespace EmployeeManagementSystem.Security
{
    public class IsApprover : AuthorizationHandler<ApproverRequirement>
    {
        private HREmployeeManagementContext _context;

        public IsApprover(HREmployeeManagementContext context)
        {
            _context = context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApproverRequirement requirement)
        {
            var employee_email = context.User.FindFirst(ClaimTypes.NameIdentifier);
            var employee = _context.Hremployee.FirstOrDefault(e => e.EmployeeEmail == employee_email.ToString());
            if (_context.HremployeeRole.Where(emp => emp.EmployeeId == employee.EmployeeId).Any(e => e.RoleId == 3))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
