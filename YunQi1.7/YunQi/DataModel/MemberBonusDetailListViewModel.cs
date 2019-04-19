namespace DataModel
{
    public class MemberBonusDetailListViewModel
    {
        public string MemberMobile { get; set; }
        public string MemberName { get; set; }
        public decimal ProductFee { get; set; }
        public int Month { get; set; }

        // 20181129 ---棋
        public int Parameters { get; set; }

        public long BonusListCount { get; set; }   //測試用
    }
}