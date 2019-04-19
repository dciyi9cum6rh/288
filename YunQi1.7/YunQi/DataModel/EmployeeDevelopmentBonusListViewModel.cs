namespace DataModel
{
    public class EmployeeDevelopmentBonusListViewModel
    {
        public string EmployeeMobile { get; set; }            //會員帳號(手機)
        public string EmployeeName { get; set; }              //會員姓名
        public long Bonus { get; set; }               //發展獎金
        public bool IsRecorded { get; set; }                //狀態
    }
}