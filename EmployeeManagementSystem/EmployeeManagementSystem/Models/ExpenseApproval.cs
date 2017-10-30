using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class ExpenseApproval
    {
        public int ExpenseId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string CurrencyShortForm { get; set; }
        public DateTime ExpenseStartDate { get; set; }
        public DateTime ExpenseEndDate { get; set; }
        public bool includeExpenseApproval { get; set; }

    }
}
