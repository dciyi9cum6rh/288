using System;

namespace DataModel
{
    //20181222 ---棋
    //前台會員中心會員調撥區
    public class MemberExchangeListViewModel
    {
        public int MessageId { get; set; }
        public int VersionId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageValue { get; set; }
        public DateTime MessageTime { get; set; }
        public string NickName { get; set; }
    }
}