using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagementSystem.Models
{
    public class SubmitExpense
    {
        public int ClaimId { get; set; }
        public int ExpenseAmount { get; set; }
        public int ExpenseCategory { get; set; }
        public int ExpenseSubCategory { get; set; }
        public IFormFile Attachment { get; set; }
        public DateTime ExpenseStartDate { get; set; }
        public DateTime ExpenseEndDate { get; set; }
        public int CurrencyId { get; set; }
    }
}