using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class TravelClaimRequestApprovalModel
    {

        public string Destination { get; set; }
        public string Purpose { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeId { get; set; }
        public int TravelClaimId { get; set; }
        public string EmployeeName { get; set; }
    }
}
