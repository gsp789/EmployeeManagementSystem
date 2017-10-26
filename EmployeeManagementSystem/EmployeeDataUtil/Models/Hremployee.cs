using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class Hremployee
    {
        public Hremployee()
        {
            HremployeeRole = new HashSet<HremployeeRole>();
            HrtravelClaim = new HashSet<HrtravelClaim>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool? IsActive { get; set; }
        public int? EmployeeManager { get; set; }
        public int? EmployeeApprover1 { get; set; }
        public int? EmployeeApprover2 { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeEmail { get; set; }
        public string Country { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string PhoneNumber { get; set; }
        public int? EmployeeCode { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<HremployeeRole> HremployeeRole { get; set; }
        public ICollection<HrtravelClaim> HrtravelClaim { get; set; }
    }
}
