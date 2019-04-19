namespace DataModel
{
    public class FollowertriumphViewModel
    {
        public string MemberMobile { get; set; }  // 下線會員手機，非訂購者手機
        public string MemberName { get; set; }    // 下線會員姓名，非訂購者姓名
        public decimal Total { get; set; }      // 單一會員訂購總額
        // public string Mybonus { get; set; }    // 我的營獎金固定為訂購媲額5%，該期間自己之訂購總額要>3000
    }
}