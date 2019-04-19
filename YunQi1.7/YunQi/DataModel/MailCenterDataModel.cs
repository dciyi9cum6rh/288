using System;

namespace DataModel
{
    //20181218 ---棋
    public class MailCenterDataModel
    {
        public int MessageId { get; set; }
        public DateTime MessageTime { get; set; }
        public string MessageValue { get; set; }
        public int MemberLevelId { get; set; }
        public string EmployeeMobile { get; set; }
        public string MessageTitle { get; set; }
    }
}