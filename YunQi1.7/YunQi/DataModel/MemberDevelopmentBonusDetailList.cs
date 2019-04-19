using System;

namespace DataModel
{
    public class MemberDevelopmentBonusDetailList
    {
        public string MemberMobile { get; set; }
        public string MemberName { get; set; }
        public DateTime VipDate { get; set; }

        // 20181129 ---棋
        public int Parameters { get; set; }

        public long BonusListCount { get; set; }   //測試用
    }
}