using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class HremployeeRole
    {
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public Hremployee Employee { get; set; }
        public Hrroles Role { get; set; }
    }
}
