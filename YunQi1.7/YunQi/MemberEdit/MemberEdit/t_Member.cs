//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MemberEdit
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Member()
        {
            this.t_MemberLog = new HashSet<t_MemberLog>();
        }
    
        public int MemberId { get; set; }
        public string MemberAccount { get; set; }
        public string MemberPassword { get; set; }
        public string NickName { get; set; }
        public Nullable<int> UpMemberID { get; set; }
        public int MemberLevelId { get; set; }
    
        public virtual t_MemberLevels t_MemberLevels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_MemberLog> t_MemberLog { get; set; }
    }
}
