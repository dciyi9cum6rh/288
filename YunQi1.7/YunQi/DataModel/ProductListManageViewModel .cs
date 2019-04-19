using System.Collections.Generic;

namespace DataModel
{
    public class ProductListManageViewModel
    {
        //public MemberListViewModel MemberListViewModel { get; set; }      // 目前會員資料
        public List<ProductListViewModel> listProductListViewModel { get; set; }

        //public long MemberCount { get; set; }  // 會員總數
        public int CurrentPage { get; set; }   // 目前頁

        public int TotalPages { get; set; }    // 總頁數
        public int PageCount { get; set; }     // 分頁頁碼連結總數
        public int StartPage { get; set; }     // 分頁頁碼起始值
        public int LinkType { get; set; }
        public string Url { get; set; }
        public string AClass { get; set; }     // 超連結Class
        public string ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
        public string Product { get; set; }
        public int lowPrice { get; set; }
        public int hightPrice { get; set; }
        public string MemberMobile { get; set; }
        public int? MemberLevelId { get; set; }
        public string NickName { get; set; }
        //public SortedList<string, object> Parameters { get; set; }          // 查訽參數
        //public List<MemberLevelsViewModel> listMemberLevelsViewModel { get; set; }  // 會員層級資料
    }
}