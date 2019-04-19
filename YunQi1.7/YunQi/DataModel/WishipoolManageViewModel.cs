using System.Collections.Generic;

namespace DataModel
{
    public class WishipoolManageViewModel
    {
        //20181222 ---棋
        public List<MemberExchangeListViewModel> listMemberExchangeListViewModel { get; set; }

        //public long MemberCount { get; set; }  // 會員總數
        public int CurrentPage { get; set; }   // 目前頁

        public int TotalPages { get; set; }    // 總頁數
        public int PageCount { get; set; }     // 分頁頁碼連結總數
        public int StartPage { get; set; }     // 分頁頁碼起始值
        public int LinkType { get; set; }
        public string Url { get; set; }
        public string AClass { get; set; }     // 超連結Class
    }
}