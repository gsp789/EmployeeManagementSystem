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
        public int? ExpenseCategoryId { get; set; }
        public int? ExpenseSubCategoryId { get; set; }
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
        public int? StatusId { get; set; }

        public HrtravelClaim Claim { get; set; }
        public Hrcurrency Currency { get; set; }
        public HrexpenseCategory ExpenseCategory { get; set; }
        public HrexpenseSubCategory ExpenseSubCategory { get; set; }
        public Hrstatus Status { get; set; }
        public ICollection<HrexpensesAttachments> HrexpensesAttachments { get; set; }
    }
}
