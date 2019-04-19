using System;

namespace DataModel
{
    //20181214 YunQiWholesale 會員點數異動

    public class BonusChangeRecordListViewModel
    {
        public string MemberMobile { get; set; }
        public DateTime ChangeTime { get; set; }
        public string Event { get; set; }
        public long BeforeBonus { get; set; }
        public long ChangeBonus { get; set; }
        public long AfterBonus { get; set; }
        public DateTime ProcessedTime { get; set; }
        public string Memo { get; set; }
    }
}