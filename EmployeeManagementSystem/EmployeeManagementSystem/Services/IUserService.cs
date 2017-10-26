using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDataUtil.Models;

namespace EmployeeManagementSystem.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string username, string password, out Hremployee employee);
    }
}
