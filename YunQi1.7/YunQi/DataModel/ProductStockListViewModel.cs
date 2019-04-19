namespace DataModel
{
    public class ProductStockListViewModel
    {
        public int ProductId { get; set; }
        public int ProducSizeId { get; set; }
        public int ProductColorId { get; set; }
        public string Product { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set; }
        public int Stock { get; set; }
    }
}