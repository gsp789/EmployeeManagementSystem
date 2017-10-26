using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class Hrroles
    {
        public Hrroles()
        {
            HremployeeRole = new HashSet<HremployeeRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<HremployeeRole> HremployeeRole { get; set; }
    }
}
