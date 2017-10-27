using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using EmployeeDataUtil.Models;

namespace EmployeeManagementSystem.Security
{
    public class IsManager: AuthorizationHandler<ManagerRequirement>
    {
        private HREmployeeManagementContext _context;

        public IsManager(HREmployeeManagementContext context)
        {
            _context = context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManagerRequirement requirement)
        {
            var employee_email = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var employee = _context.Hremployee.FirstOrDefault(e => e.EmployeeEmail == employee_email.ToString());
            if(_context.HremployeeRole.Where(emp => emp.EmployeeId == employee.EmployeeId).Any(e => e.RoleId == 2))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
