using System.Collections.Generic;

namespace DataModel
{
    public class FollowertriumphManageViewModel
    {
        //public MemberListViewModel MemberListViewModel { get; set; }      // 目前會員資料
        public List<FollowertriumphViewModel> listFollowertriumphViewModel { get; set; }

        //public long MemberCount { get; set; }  // 會員總數
        public int CurrentPage { get; set; }   // 目前頁

        public int TotalPages { get; set; }    // 總頁數
        public int PageCount { get; set; }     // 分頁頁碼連結總數
        public int StartPage { get; set; }     // 分頁頁碼起始值
        public int LinkType { get; set; }
        public string Url { get; set; }
        public string AClass { get; set; }     // 超連結Class
        public FollowertriumphTotalViewModel FollowertriumphTotall { get; set; }     // 下線批發總額
        public FollowertriumphTotalViewModel MemberTotall { get; set; }              // 會員批發總額

        //20181121 ---棋
        public decimal Bonus { get; set; }   //營運獎金

        public int Parameters { get; set; }
        public long memberCount { get; set; }  ///test
        public long test { get; set; } //test

        //public SortedList<string, object> Parameters { get; set; }          // 查訽參數
        //public List<MemberLevelsViewModel> listMemberLevelsViewModel { get; set; }  // 會員層級資料
    }
}