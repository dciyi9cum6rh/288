using System;

namespace DataModel
{
    //20181220 ---棋
    //YunQiERP 留言板管理清單
    public class MessageManagementListViewModel
    {
        public string VersionName { get; set; }
        public int VersionId { get; set; }
        public int MessageId { get; set; }
        public string MessageValue { get; set; }
        public DateTime MessageTime { get; set; }
        public string MemberMobile { get; set; }
        public string NickName { get; set; }
        public string MessageTitle { get; set; }
    }
}