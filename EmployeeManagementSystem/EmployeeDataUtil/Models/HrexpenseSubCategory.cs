using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class HrexpenseSubCategory
    {
        public HrexpenseSubCategory()
        {
            Hrexpenses = new HashSet<Hrexpenses>();
        }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryDescription { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public string AccountCode { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Limit { get; set; }
        public bool? AttachmentNecessary { get; set; }
        public DateTime? ValidFrom { get; set; }

        public HrexpenseCategory Category { get; set; }
        public ICollection<Hrexpenses> Hrexpenses { get; set; }
    }
}
