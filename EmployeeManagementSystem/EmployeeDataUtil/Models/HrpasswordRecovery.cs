using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class HrpasswordRecovery
    {
        public string Email { get; set; }
        public int? EmployeeId { get; set; }
        public string RecoveryCode { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public int Id { get; set; }
    }
}
