using System;

namespace DataModel
{
    public class ProductListViewModel
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategory { get; set; }
        public string Product { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public int OfferPrice { get; set; }
        public int SaleLimitPrice { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}