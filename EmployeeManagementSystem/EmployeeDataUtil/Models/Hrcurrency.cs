using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class Hrcurrency
    {
        public Hrcurrency()
        {
            Hrexpenses = new HashSet<Hrexpenses>();
        }

        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyType { get; set; }
        public string Country { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Hrexpenses> Hrexpenses { get; set; }
    }
}
