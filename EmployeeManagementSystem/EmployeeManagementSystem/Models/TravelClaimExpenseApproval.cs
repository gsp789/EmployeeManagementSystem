using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class TravelClaimExpenseApproval
    {
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { set; get; }
        public List<ExpenseApproval> expense { get; set; }
        public List<string> Status { get; set; }
    }
}
