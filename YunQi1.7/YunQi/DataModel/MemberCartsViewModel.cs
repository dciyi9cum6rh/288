using System;

namespace DataModel
{
    public class MemberCartsViewModel
    {
        public string MemberMobile { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int ProducSizeId { get; set; }
        public int ProductColorId { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}