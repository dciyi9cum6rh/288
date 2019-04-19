using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberEdit
{
    public class DataRepositoryBase
    {
        #region 資料成員

        // 資料庫成員：代表GFriend資料庫
        public ACCPlatformEntities cae;

        #endregion

        #region 建構式

        // 在建構函式中建立GFriendEntities物件
        public DataRepositoryBase()
        {
            cae = new ACCPlatformEntities();
        }

        // 以參數在建構函式中建立GFriendEntities物件
        public DataRepositoryBase(ACCPlatformEntities cae)
        {
            this.cae = cae;
        }


        #endregion

        #region 方法

        // 存檔
        public void save()
        {
            cae.SaveChanges();
        }

        //// 確定資料庫連總關閉
        //public  override void Dispose()
        //{
        //    cae.Dispose();
        //    //base.Dispose(disposing);
        //}


        #endregion
    }
}
