using System.Collections.Generic;

namespace DataModel
{
    public class GetLedgerMonthListManageViewModel
    {
        //20181214 ---棋
        public List<GetLedgerMonthListViewModel> listGetLedgerMonthListViewModel { get; set; }

        public long AddMoney { get; set; }
        public long MinusMoney { get; set; }
    }
}