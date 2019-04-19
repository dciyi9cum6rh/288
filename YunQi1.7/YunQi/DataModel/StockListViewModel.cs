using System;

namespace DataModel
{
    public class StockListViewModel
    {
        public int ProductStockConsolidationId { get; set; }
        public DateTime StockConsolidationTime { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int ProducSizeId { get; set; }
        public int ProductColorId { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set; }
        public int Stock { get; set; }
        public int StockConsolidatio { get; set; }
        public int Consolidation { get; set; }
        public string UpdateEmployeeMobile { get; set; }
    }
}