namespace DataModel
{
    //20181214 ---棋
    public class GetLedgerMonthListViewModel
    {
        public int Month { get; set; }
        public int AccountingId { get; set; }
        public string AccountingSubject { get; set; }
        public long AddMoney { get; set; }
        public long MinusMoney { get; set; }
    }
}