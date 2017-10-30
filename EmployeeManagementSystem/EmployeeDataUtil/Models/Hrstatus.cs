using System;
using System.Collections.Generic;

namespace EmployeeDataUtil.Models
{
    public partial class Hrstatus
    {
        public Hrstatus()
        {
            Hrexpenses = new HashSet<Hrexpenses>();
            HrtravelClaim = new HashSet<HrtravelClaim>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<Hrexpenses> Hrexpenses { get; set; }
        public ICollection<HrtravelClaim> HrtravelClaim { get; set; }
    }
}
