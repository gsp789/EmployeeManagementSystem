using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class Hrexpenses
    {
        public Hrexpenses()
        {
            HrexpensesAttachments = new HashSet<HrexpensesAttachments>();
        }

        public int ExpenseId { get; set; }
        public int? ExpenseCategory { get; set; }
        public int? ExpenseSubCategory { get; set; }
        public decimal? ExpenseAmount { get; set; }
        public DateTime? ExpenseStartDate { get; set; }
        public DateTime? ExpenseEndDate { get; set; }
        public int? ClaimId { get; set; }
        public int? CurrencyId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public HrtravelClaim Claim { get; set; }
        public Hrcurrency Currency { get; set; }
        public ICollection<HrexpensesAttachments> HrexpensesAttachments { get; set; }
    }
}
