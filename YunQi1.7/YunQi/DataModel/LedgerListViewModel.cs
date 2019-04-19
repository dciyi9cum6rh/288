namespace DataModel
{
    //20181213 ---棋
    public class LedgerListViewModel
    {
        public string AccountingId { get; set; }
        public int LedgerId { get; set; }
        public string AccountingSubject { get; set; }
        public long Money { get; set; }
        public string InvoiceId { get; set; }
        public string LedgerDescription { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}