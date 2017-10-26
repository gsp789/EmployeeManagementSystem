using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class Hruser
    {
        public string Email { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeePassword { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastLogedIn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
