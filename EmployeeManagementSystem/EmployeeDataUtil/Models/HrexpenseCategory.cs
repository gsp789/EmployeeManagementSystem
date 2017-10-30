using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class HrexpenseCategory
    {
        public HrexpenseCategory()
        {
            HrexpenseSubCategory = new HashSet<HrexpenseSubCategory>();
            Hrexpenses = new HashSet<Hrexpenses>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public string AccountCode { get; set; }

        public ICollection<HrexpenseSubCategory> HrexpenseSubCategory { get; set; }
        public ICollection<Hrexpenses> Hrexpenses { get; set; }
    }
}
