using System.Collections.Generic;

namespace DataModel
{
    public class ProductDetailMallViewModel
    {
        public ProductListViewModel Product { get; set; }
        public List<ProductSizeViewModel> ProductSize { get; set; }
        public List<ProductColorViewModel> ProductColor { get; set; }
        public ProductStockListViewModel ProductStock { get; set; }
        public List<ProductImageListViewModel> ProductImage { get; set; }
        public int? MemberLevelId { get; set; }
    }
}