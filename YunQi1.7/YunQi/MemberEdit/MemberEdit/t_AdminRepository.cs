using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberEdit
{
    public class t_MemberRepository:DataRepositoryBase
    {
        #region 建構式

        public t_MemberRepository(ACCPlatformEntities cae)
            : base(cae)
        {
        }

        #endregion

        #region 方法成員

        // 建立一管理者
        public void Create(int MemberID,string MemberAccount, string MemberPassword, string NickName, int MemberLevel, int? UpMemberID=null)
        {
            t_Member ta = new t_Member();
            ta.MemberId = MemberID;
            ta.MemberAccount = MemberAccount;
            ta.MemberPassword = HashPassword(MemberPassword);
            ta.NickName = NickName;
            ta.UpMemberID = UpMemberID;
            ta.MemberLevelId = MemberLevel;
            cae.t_Member.Add(ta);
        }

        // 更新密碼
        public void UpdatePassword(string MemberAccount, string MemberPassword)
        {
            t_Member tm = cae.t_Member.FirstOrDefault(m => m.MemberAccount == MemberAccount);
            tm.MemberPassword = HashPassword(MemberPassword);
        }

        // 驗証(讀取)網站管理員
        public t_Member Get(string MemberAccount, string MemberPassword)
        {
            MemberPassword = HashPassword(MemberPassword);
            return cae.t_Member.FirstOrDefault(m => m.MemberAccount == MemberAccount && m.MemberPassword == MemberPassword);
        }

        // 將密碼編碼的方法
        private string HashPassword(string str)
        {
            string rethash = "";

            System.Security.Cryptography.SHA256 hash = System.Security.Cryptography.SHA256.Create();
            System.Text.ASCIIEncoding encoder = new System.Text.ASCIIEncoding();
            byte[] combined = encoder.GetBytes(str);
            hash.ComputeHash(combined);
            rethash = Convert.ToBase64String(hash.Hash);

            return rethash;
        }


        #endregion
    }
}
