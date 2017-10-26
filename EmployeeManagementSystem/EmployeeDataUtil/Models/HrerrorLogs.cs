using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class HrerrorLogs
    {
        public int LogId { get; set; }
        public int? EmployeeId { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
