namespace DataModel
{
    //20181203 ---棋
    public class MemberDevelopmentBonusListViewModel
    {
        public string MemberMobile { get; set; }            //會員帳號(手機)
        public string MemberName { get; set; }              //會員姓名
        public long Bonus { get; set; }               //發展獎金
        public bool IsRecorded { get; set; }                //狀態
                                                            // public int DateTime { get; set; }                   //入帳時間
    }
}