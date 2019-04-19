using System;

namespace DataModel
{
    public class MemberViewModel
    {
        public string MemberMobile { get; set; }
        public int MemberLevelId { get; set; }
        public string MemberLevel { get; set; }
        public string MemberName { get; set; }
        public string NickName { get; set; }
        public byte sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string eMail { get; set; }
        public string LineId { get; set; }
        public string Phone { get; set; }
        public string ContactAddress { get; set; }
        public string ID { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string AccountNunber { get; set; }
        public string AccountName { get; set; }
        public DateTime? Duedate { get; set; }
        public DateTime? VipApplyDate { get; set; }
        public DateTime? VipDate { get; set; }
        public string ReferrerMobile { get; set; }
        public byte Enabled { get; set; }

        //20181212 ---棋
        public string FileName { get; set; }

        public byte[] PictureContent { get; set; }
        public string PictureType { get; set; }

        //20181215 ---棋
        public long Bonus { get; set; }

        public int Month { get; set; }

        public long OrderBonus { get; set; }
    }
}