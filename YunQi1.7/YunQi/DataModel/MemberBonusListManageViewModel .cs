﻿using System.Collections.Generic;

namespace DataModel
{
    public class MemberBonusListManageViewModel
    {
        public List<MemberBonusListViewModel> listMemberBonusListViewModel { get; set; }
        public int CurrentPage { get; set; }   // 目前頁
        public int TotalPages { get; set; }    // 總頁數
        public int PageCount { get; set; }     // 分頁頁碼連結總數
        public int StartPage { get; set; }     // 分頁頁碼起始值
        public int LinkType { get; set; }
        public string Url { get; set; }
        public string AClass { get; set; }     // 超連結Class

        // 20181129 ---棋
        public int Parameters { get; set; }

        public long BonusListCount { get; set; }   //測試用
        //public SortedList<string, object> Parameters { get; set; }          // 查訽參數
        //public List<MemberLevelsViewModel> listMemberLevelsViewModel { get; set; }  // 會員層級資料
    }
}