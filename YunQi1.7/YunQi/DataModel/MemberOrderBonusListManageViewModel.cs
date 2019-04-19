using System.Collections.Generic;

namespace DataModel
{
    public class MemberOrderBonusListManageViewModel
    {
        //public MemberListViewModel MemberListViewModel { get; set; }      // 目前會員資料
        public List<MemberOrderBonusListViewModel> listMemberOrderBonusListViewModel { get; set; }

      
        public int CurrentPage { get; set; }   // 目前頁
        public int TotalPages { get; set; }    // 總頁數
        public int PageCount { get; set; }     // 分頁頁碼連結總數
        public int StartPage { get; set; }     // 分頁頁碼起始值
        public int LinkType { get; set; }
        public string Url { get; set; }      
    }
}