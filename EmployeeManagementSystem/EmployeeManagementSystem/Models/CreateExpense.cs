using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDataUtil.Models;

namespace EmployeeManagementSystem.Models
{
    public class CreateExpenseModel
    {
        public List<HrexpenseCategory> CategoryList;
        public List<HrexpenseSubCategory> SubCategoryList;
        public HrtravelClaim SelectedTravelClaim;
        public List<Hrcurrency> CurrencyList;
        public List<Hrexpenses> Expenses;
    }
}