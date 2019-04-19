namespace DataModel
{
    //20190104 ---棋
    public class OrderCheckProductStockEnoughViewModel
    {
        public string OrderId { get; set; }
        public string Product { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set; }
        public int Stock { get; set; }
    }
}