using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeDataUtil.Models;
using System.Security.Claims;
using EmployeeDataUtil;

namespace EmployeeManagementSystem.Controllers
{
    public class PreTravelClaimController : Controller
    {
        private HREmployeeManagementContext _context;
        private IEmailSender _emailSender;

        public PreTravelClaimController(HREmployeeManagementContext context)
        {
            _context = context;
            _emailSender = new EmailSender();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(TravelClaimRequestViewModel model)
        {
            HrtravelClaim claim = new HrtravelClaim();
            var employee = _context.Hremployee.FirstOrDefault(emp => emp.EmployeeEmail == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            

            claim.EmployeeId = employee.EmployeeId;
            claim.Destination = model.Destination;
            claim.StartDate = model.StartDate;
            claim.EndTime = model.EndDate;
            claim.BusinessPurpose = model.Purpose.Trim();
            claim.CreatedBy = employee.EmployeeName;
            claim.CreatedDateTime = DateTime.Now;
            claim.ModifiedDate = DateTime.Now;
            _context.HrtravelClaim.Add(claim);
            _context.SaveChanges();
            Dictionary< string,string> emailAddresses = GetApproversAndManagersList(employee.EmployeeId);

            var claimSaved = from tempClaim in _context.HrtravelClaim
                             where tempClaim.Destination == claim.Destination && tempClaim.EmployeeId == employee.EmployeeId
                             && tempClaim.StartDate.Value.Date == model.StartDate.Date && tempClaim.EndTime.Value.Date == model.EndDate.Date
                             select tempClaim;

            if(claimSaved.Any())
            {
                SendEmailToAllApprovers(emailAddresses, claimSaved.First().ClaimId,employee.EmployeeId);
            }
            
            return View();
        }

        public Dictionary<string,string> GetApproversAndManagersList(int EmployeeId)
        {
            var temp = from employee in _context.Hremployee
                       where employee.EmployeeId == EmployeeId && employee.IsActive == true
                       select employee;
            Hremployee emp = temp.ToList().First();
            Dictionary<string,string> emailsDict = new Dictionary<string, string>();


            var approver1Email = findEmailAddress(emp.EmployeeApprover1);
            emailsDict.Add("Approver1", approver1Email);
            var approver2Email = findEmailAddress(emp.EmployeeApprover2);
            emailsDict.Add("Approver2", approver1Email);
            var ManagerEmail = findEmailAddress(emp.EmployeeManager);
            emailsDict.Add("Manager", approver1Email);

            return emailsDict;

        }


        public string findEmailAddress(int? EmployeeId)
        {
            if(EmployeeId != null)
            {
                var email = from employee in _context.Hremployee
                            where employee.EmployeeId == EmployeeId && employee.IsActive == true
                            select employee.EmployeeEmail;
                if (email.Any())
                {
                    return email.ToList().First();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void SendEmailToAllApprovers(Dictionary<string,string> empEmailDict,int claimID,int EmployeeId)
        {
            string temp = @"<html>
                               <body>
                                   <a href=""localhost:35550/ApproveTravelClaim?ClaimID={0}"" >Approve Claim</a>
                               </body>
                            <html>";
            string body = String.Format(temp, claimID.ToString());
            Email email = new Email();
            email.body = body;
            email.subject = String.Format("Approve Travel Claim for EmployeeId {0}", EmployeeId.ToString());
            email.fromAddress = "";
            foreach(KeyValuePair<string,string> keys in empEmailDict)
            {
                if(keys.Key == "Approver1" || keys.Key == "Approver2")
                {
                    email.toAddress.Add(keys.Value);
                }
                else
                {
                    email.ccAddress.Add(keys.Value);
                }
            }
            _emailSender.SendEmail(email);
        }

    }
}