using System.Collections.Generic;
using System;

namespace DataModel
{
    public class MemberOrderBonusListViewModel
    {       
        public string MemberMobile { get; set; }
        public string OrderId { get; set; }       
        public decimal Amount { get; set; }
        public decimal OrderBonus { get; set; }
        public DateTime RecordTime { get; set; }
    }
}