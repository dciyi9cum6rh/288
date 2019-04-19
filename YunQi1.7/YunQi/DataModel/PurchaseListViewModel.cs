using System;

namespace DataModel
{
    public class PurchaseListViewModel
    {
        public string PurchaseId { get; set; }
        public DateTime PurchaseTime { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Freight { get; set; }
        public decimal FreightNT { get; set; }
        public decimal miscellaneous { get; set; }
        public decimal miscellaneousNT { get; set; }
        public decimal ProductFee { get; set; }
        public decimal ProductFeeNT { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalExpenseNT { get; set; }
        public string UpdateEmployeeMobile { get; set; }
    }
}