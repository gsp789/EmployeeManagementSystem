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
        public Task<bool> ValidateCredentials(string username, string password, out Hruser user)
        {
            user = null;
            var verifyUser = _context.Hruser.FirstOrDefault(e => e.Email == username && e.IsActive == true);
            if(verifyUser != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, verifyUser.EmployeePassword)) //Verify Password
                {
                    user = verifyUser;
                    return Task.FromResult(true);
                }
            }
            return Task.FromResult(false);
        }
    }
}
