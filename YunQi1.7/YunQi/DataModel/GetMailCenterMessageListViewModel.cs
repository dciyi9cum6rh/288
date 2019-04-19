using System;

namespace DataModel
{
    //20181218 ---棋
    public class GetMailCenterMessageListViewModel
    {
        public int MessageId { get; set; }
        public string MessageValue { get; set; }
        public DateTime MessageTime { get; set; }
        public string MemberLevel { get; set; }
        public int MemberLevelid { get; set; }
        public string EmployeeMobile { get; set; }
        public string MessageTitle { get; set; }
    }
}