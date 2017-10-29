using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public interface IEmailService
    {
        void PasswordRecoveryEmail(string to_address, string guid);
    }
}
