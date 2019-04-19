using System.Collections.Generic;

namespace DataModel
{
    public class CartListViewModel
    {
        public string OrderId { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int ProducSizeId { get; set; }
        public int ProductColorId { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int SubTotal { get; set; }
        public List<ProductSizeViewModel> lstPSVM { get; set; }
        public List<ProductColorViewModel> lstPCVM { get; set; }
    }
}