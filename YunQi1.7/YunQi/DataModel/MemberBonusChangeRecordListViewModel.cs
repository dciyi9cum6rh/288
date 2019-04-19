using System;

namespace DataModel
{
    //2181215 ---棋
    public class MemberBonusChangeRecordListViewModel
    {
        public int RecordId { get; set; }
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