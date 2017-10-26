using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class HrexpensesAttachments
    {
        public int AttachmentId { get; set; }
        public int? ExpenseId { get; set; }
        public string FilePath { get; set; }
        public string ExpenseFileName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public Hrexpenses Expense { get; set; }
    }
}
