using System.Collections.Generic;

namespace DataModel
{
    public class CartHomesViewModel
    {
        public List<CartListViewModel> lstCLVM { get; set; }
        public MemberViewModel MVM { get; set; }
        public OrderFreightViewModel Freight { get; set; }

        //20181220 ---棋
        public List<MemberDeliveryAddressListViewModel> MDAL { get; set; }
    }
}