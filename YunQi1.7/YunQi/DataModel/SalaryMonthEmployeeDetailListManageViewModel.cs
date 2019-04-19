using System.Collections.Generic;

namespace DataModel
{
    //20181211  ---棋
    public class SalaryMonthEmployeeDetailListManageViewModel
    {
        public List<GetEmployeeBaseSalaryViewModel> lGEBS { get; set; }
        public List<SalaryClassListViewModel> lSCLVM { get; set; }
        public List<SalaryMonthEmployeeDetailListViewModel> LSMEDLVM { get; set; }
    }
}