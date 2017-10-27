using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDataUtil.Models;

namespace EmployeeManagementSystem.Services
{
    public class UserService : IUserService
    {
        private HREmployeeManagementContext _context;

        public UserService(HREmployeeManagementContext context)
        {
            _context = context;
        }
        public Task<bool> ValidateCredentials(string username, string password, out Hremployee employee)
        {
            employee = null;
            var emp = _context.Hremployee.FirstOrDefault(e => e.EmployeeEmail == username && e.IsActive == true);
            if(emp != null)
            {
                var hash = BCrypt.Net.BCrypt.HashPassword("Hemanth#123");
                //BCrypt.Net.BCrypt.Verify(password, emp.password) //Verify Password
                employee = emp;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
