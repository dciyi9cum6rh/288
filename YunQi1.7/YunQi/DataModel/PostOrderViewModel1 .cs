using System.Collections.Generic;

namespace DataModel
{
    public class PostOrderViewModel1
    {
        public List<CartListViewModel> OrderDetail { get; set; }
        public ContactDataViewModel ContactData { get; set; }
        public int CartTobal { get; set; }
        public string OrderId { get; set; }
        public TradeSPToken RtnModel { get; set; }

        //20181213 ---棋
        public string MemberMobile { get; set; }

        public int ret { get; set; }
        public string product { get; set; }
        public List<OrderCheckProductStockEnoughViewModel> OCPSE { get; set; }
    }
}