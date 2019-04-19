namespace DataModel
{
    public class PurchaseDetailListViewModel
    {
        public string PurchaseId { get; set; }
        public int PurchaseDetailId { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int ProducSizeId { get; set; }
        public string ProductSize { get; set; }
        public int ProductColorId { get; set; }
        public string ProductColor { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public decimal ProductFee { get; set; }
        public decimal Freight { get; set; }
        public decimal miscellaneous { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalExpenseNT { get; set; }
        public decimal PurchasePriceTotalNT { get; set; }
    }
}