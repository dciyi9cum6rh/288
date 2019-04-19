using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberEdit
{
    public class t_AdminBackendRepository : DataRepositoryBase
    {
        #region 建構式

        public t_AdminBackendRepository(ACCPlatformEntities cae)
            : base(cae)
        {
        }

        #endregion

        #region 方法成員

        // 建立一管理者
        public void Create(string AdminAccount, string Password, string NickName)
        {
            t_Admin ta = new t_Admin();
            ta.AdminAccount = AdminAccount;
            ta.Password = HashPassword(Password);
            ta.NickName = NickName;
            ta.LastLoginTime = null;
            ta.UpdateTime = DateTime.Now;
            cae.t_Admin.Add(ta);
        }

        // 更新密碼
        public void UpdatePassword(string AdminAccount, string Password)
        {
            t_Admin tm = cae.t_Admin.FirstOrDefault(m => m.AdminAccount == AdminAccount);
            tm.Password = HashPassword(Password);
        }

        // 驗証(讀取)網站管理員
        public t_Admin Get(string AdminAccount, string Password)
        {
            Password = HashPassword(Password);
            return cae.t_Admin.FirstOrDefault(m => m.AdminAccount == AdminAccount && m.Password == Password);
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
