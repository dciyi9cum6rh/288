namespace DataModel
{
    public class MemberBonusListViewModel
    {
        public string MemberMobile { get; set; }
        public string MemberName { get; set; }
        public long MemberOrderSum { get; set; }
        public long OfflineMemberOrderSum { get; set; }
        public long MemberBonus { get; set; }
        public bool IsRecorded { get; set; }
        public int Month { get; set; }
    }
}