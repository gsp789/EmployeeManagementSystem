using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDataUtil.Models
{
    public partial class HrtravelClaim
    {
        public HrtravelClaim()
        {
            Hrexpenses = new HashSet<Hrexpenses>();
        }

        public int ClaimId { get; set; }
        public int? EmployeeId { get; set; }
        public int? StatusId { get; set; }
        public int? ApprovedEmployeeId { get; set; }
        
        public string Destination { get; set; }
        [Display(Name = "Travel Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Travel End Date")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "Business Purpose")]
        public string BusinessPurpose { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public Hremployee Employee { get; set; }
        public Hrstatus Status { get; set; }
        public ICollection<Hrexpenses> Hrexpenses { get; set; }
    }
}
