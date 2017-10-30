using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeManagementSystem.Services
{
    public class HelperMethods
    {
        private static IHttpContextAccessor HttpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        private static string GetHost()
        {
            var request = HttpContextAccessor.HttpContext.Request;
            return string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
        }

        public static string PasswordRecoveryUrl(string guid)
        {
            return GetHost() + "/ForgotPassword/RecoverPassword/" + guid;
        }
    }
}
