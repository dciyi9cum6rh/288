using Dapper;
using DataModel;
using IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataEntity
{
    public class MemberRepository : IMemberRepository
    {
        public string constr { get; set; }

        public MemberRepository()
        {
            constr = "";
            //con = new SqlConnection(constr);
        }

        public MemberRepository(string connection)
        {
            constr = connection;
            //con = new SqlConnection(constr);
        }

        //------------------------------------------20190103 Sync銷貨管理
        public int SyncUpdateOrderState(string OrderId, byte OrderStateId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@OrderStateId", OrderStateId, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    con.OpenAsync();
                    con.Execute("sp_UpdateOrderState", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        //------------------------------------------20190103 Sync銷貨管理

        //------------------------------------------20181222 YunQiWholesale 會員調撥區
        //20181222 ---棋
        //9-2.系統在ViewComponent【GetMemberMailCenterMessageCount】讀取會員調撥區總數。
        public async Task<long> GetMemberExchangeCount(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string NickName)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@VersionId", VersionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@MessageValue", MessageValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@NickName", NickName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberExchangeCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181222 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取送會員調撥區清單：
        public async Task<List<MemberExchangeListViewModel>> GetMemberExchangeList(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string NickName, int Skip = 0, int RowsPerPage = 10)
        {
            List<MemberExchangeListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@VersionId", VersionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@MessageValue", MessageValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@NickName", NickName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberExchangeListViewModel> tmp = await con.QueryAsync<MemberExchangeListViewModel>("sp_GetMemberExchangeList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberExchangeListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181222 ---棋
        //9-2.系統在ViewComponent【GetMemberMailCenterMessageCount】新增會員調撥區留言。
        public async Task<long> InsertMessageManagement(int VersionId, string MessageTitle, string MessageValue, string MemberMobile)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@VersionId", VersionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@MessageTitle", MessageTitle, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MessageValue", MessageValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_InsertMessageManagement", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //------------------------------------------20181222 YunQiWholesale 會員調撥區

        public async Task<List<MemberCartOneListViewModel>> GetMemberCartOneList(string MemberMobile, int ProductId, int ProductSizeId, int ProductColorId)
        {
            List<MemberCartOneListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductSizeId", ProductSizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductColorId", ProductColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberCartOneListViewModel> tmp = await con.QueryAsync<MemberCartOneListViewModel>("sp_GetMemberCartOneList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberCartOneListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181222 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取送會員調撥區清單：
        //public async Task<List<MemberCartOneListViewModel>> GetMemberCartOneList(string MemberMobile, int ProductId,int ProductSizeId,int ProductColorId)
        //{
        //    List<MemberCartOneListViewModel> ret = null;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(constr))
        //        {
        //            var p = new DynamicParameters();
        //            p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
        //            p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //            p.Add("@ProductSizeId", ProductSizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //            p.Add("@ProductColorId", ProductColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //            p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
        //            await con.OpenAsync();
        //            IEnumerable<MemberCartOneListViewModel> tmp = await con.QueryAsync<MemberCartOneListViewModel>("sp_GetMemberCartOneList", p, commandType: CommandType.StoredProcedure);
        //            ret = tmp.ToList<MemberCartOneListViewModel>();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //        ret = null;
        //    }
        //    return ret;
        //}

        //------------------------------------------20181220 YunQiWholesale 送貨地址
        //20181220 ---棋
        //9-2.系統在ViewComponent【GetMemberMailCenterMessageCount】讀取送貨地址總數。
        public async Task<long> GetMemberDeliveryAddressCount(string MemberMobile, string MemberName, string Phone, string DeliveryAddress)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Phone", Phone, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@DeliveryAddress", DeliveryAddress, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberDeliveryAddressCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181220 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取送貨地址清單：
        public async Task<List<MemberDeliveryAddressListViewModel>> GetMemberDeliveryAddressList(string MemberMobile, string MemberName, string Phone, string DeliveryAddress, int Skip = 0, int RowsPerPage = 10)
        {
            List<MemberDeliveryAddressListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Phone", Phone, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@DeliveryAddress", DeliveryAddress, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberDeliveryAddressListViewModel> tmp = await con.QueryAsync<MemberDeliveryAddressListViewModel>("sp_GetMemberDeliveryAddressList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberDeliveryAddressListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181220 ---棋
        //9-2.系統在ViewComponent【GetMemberMailCenterMessageCount】新增送貨地址。
        public async Task<long> InsertMemberDeliveryAddress(string MemberMobile, string MemberName, string Phone, string DeliveryAddress, string eMail)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Phone", Phone, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@DeliveryAddress", DeliveryAddress, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@eMail", eMail, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_InsertMemberDeliveryAddress", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181220 ---棋
        //9-2.系統在ViewComponent【GetMemberMailCenterMessageCount】更改送貨地址。
        public async Task<long> UpdateMemberDeliveryAddress(int MemberAddressId, string MemberMobile, string MemberNameN, string PhoneN, string DeliveryAddressN, string eMailN)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberAddressId", MemberAddressId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberNameN", MemberNameN, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PhoneN", PhoneN, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@DeliveryAddressN", DeliveryAddressN, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@eMailN", eMailN, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_UpdateMemberDeliveryAddress", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181220 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取送貨地址清單：
        public async Task<List<MemberDeliveryAddressListViewModel>> GetMemberDeliveryAddress(string MemberMobile, int MemberAddressId)
        {
            List<MemberDeliveryAddressListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberAddressId", MemberAddressId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberDeliveryAddressListViewModel> tmp = await con.QueryAsync<MemberDeliveryAddressListViewModel>("sp_GetMemberDeliveryAddress", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberDeliveryAddressListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //------------------------------------------20181220 YunQiWholesale 送貨地址

        //------------------------------------------20181217 YunQiWholesale 訊息中心
        //20181218 ---棋
        //9-2.系統在ViewComponent【GetMemberMailCenterMessageCount】讀取訊息總數。
        public async Task<long> GetMemberMailCenterMessageCount(string MemberMobile, string MessageValue)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MessageValue", MessageValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberMailCenterMessageCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181218 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取訊息清單：
        public async Task<List<MemberMailCenterMessageListViewModel>> GetMemberMailCenterMessageList(string MemberMobile, string MessageValue, int Skip = 0, int RowsPerPage = 10)
        {
            if (MemberMobile == null) MemberMobile = "";
            List<MemberMailCenterMessageListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MessageValue", MessageValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberMailCenterMessageListViewModel> tmp = await con.QueryAsync<MemberMailCenterMessageListViewModel>("sp_GetMemberMailCenterMessageList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberMailCenterMessageListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181218 ---棋
        //查依批發會員等級查會員清單
        public async Task<List<MemberLevelListViewModel>> GetMemberLevelList(int MemberLevelid)
        {
            List<MemberLevelListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberLevelid", MemberLevelid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberLevelListViewModel> tmp = await con.QueryAsync<MemberLevelListViewModel>("sp_GetMemberLevelList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberLevelListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181218 ---棋
        //依照會員等級名稱回傳會員等級ID
        public async Task<List<MemberLevelViewModel>> GetMembevLevel(string MemberLevel)
        {
            List<MemberLevelViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberLevel", MemberLevel, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberLevelViewModel> tmp = await con.QueryAsync<MemberLevelViewModel>("sp_GetMemberLevel", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberLevelViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        //20181218 ---棋
        //新增前台訊息
        public async Task<int> InsertMemberMessage(List<memberMailCenter> memberMailCenter)
        {
            string sqlDelete = @"Insert into t_MemberMessage(MemberMobile,MessageId,MemberLevelId)Values(@MemberMobile,@MessageId,@MemberLevelId)";
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    await con.OpenAsync();
                    using (var trans = con.BeginTransaction())
                    {
                        await con.ExecuteAsync(sqlDelete, memberMailCenter, commandType: CommandType.Text, transaction: trans);
                        try
                        {
                            trans.Commit();
                        }
                        catch (Exception exi)
                        {
                            trans.Rollback();
                            ret = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        //20181219 ---棋
        //會員讀取未讀訊息總數
        public async Task<long> GetMailCenterUnReadCount(string MemberMobile)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMailCenterUnReadCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181219 ---棋
        //會員讀取未讀訊息更新為全部已讀
        public async Task<long> UpdateMailCenterReadStates(string MemberMobile)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_UpdateMailCenterReadStates", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //------------------------------------------20181217 YunQiWholesale 訊息中心

        //------------------------------------------2018 YunQiWholesale 登入/註冊
        public async Task<int> InsertMember(string MemberMobile, string Password, int MemberLevelId, string MemberName, string NickName, byte sex,
            string eMail, string ContactAddress, int ValidateCode)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Password", Password, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberLevelId", MemberLevelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@NickName", NickName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sex", sex, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    //p.Add("@Birthday", Birthday, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add("@eMail", eMail, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@LineId", LineId, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@Phone", Phone, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ContactAddress", ContactAddress, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@ID", ID, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@Bank", Bank, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@Branch", Branch, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@AccountNunber", AccountNunber, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@AccountName", AccountName, dbType: DbType.String, direction: ParameterDirection.Input);
                    //20181216 --棋
                    //新增會員手機驗證碼
                    p.Add("@ValidateCode", ValidateCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertMember", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<int> MemberLogin(string MemberMobile, string Password)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.AnsiString, direction: ParameterDirection.Input);
                    p.Add("@Password", Password, dbType: DbType.AnsiString, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_MemberLogin", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        //20181216 ---棋
        //手機簡訊驗證
        public async Task<int> MemberVerification(string MemberMobile, int ValidateCode)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.AnsiString, direction: ParameterDirection.Input);
                    p.Add("@ValidateCode", ValidateCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_MemberMobileCheck", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        //------------------------------------------2018 YunQiWholesale 登入/註冊

        //------------------------------------------20181214 YunQiWholesale 會員點數異動
        //20181214 ---棋
        //9-2.系統在ViewComponent【sp_GetMemberDevelopmentBonusDetailListCount】讀取批發會員獎金記錄總數。
        public async Task<long> GetBonusChangeRecordCount(string MemberMobile, DateTime? sDate, DateTime? eDate)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetBonusChangeRecordCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181203 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取批發會員獎金清單：
        public async Task<List<BonusChangeRecordListViewModel>> GetBonusChangeRecordList(string MemberMobile, DateTime? sDate, DateTime? eDate, int Skip = 0, int RowsPerPage = 10)
        {
            if (MemberMobile == null) MemberMobile = "";
            List<BonusChangeRecordListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<BonusChangeRecordListViewModel> tmp = await con.QueryAsync<BonusChangeRecordListViewModel>("sp_GetBonusChangeRecordList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<BonusChangeRecordListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //------------------------------------------20181214 YunQiWholesale 會員點數異動

        //------------------------------------------20181214 YunQiERP 會員點數異動
        //20181215 ---棋
        //9-2.系統在ViewComponent【sp_GetMemberDevelopmentBonusDetailListCount】讀取批發會員獎金記錄總數。
        public async Task<long> GetMemberBonusChangeRecordCount(string MemberMobile, DateTime? sDate, DateTime? eDate)
        {
            if (MemberMobile == null) MemberMobile = "";
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberBonusChangeRecordCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181215 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取批發會員獎金清單：
        public async Task<List<MemberBonusChangeRecordListViewModel>> GetMemberBonusChangeRecordList(string MemberMobile, int EventId,DateTime? sDate, DateTime? eDate, int Skip = 0, int RowsPerPage = 10)
        {
            if (MemberMobile == null) MemberMobile = "";
            List<MemberBonusChangeRecordListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    if (EventId > 0) { p.Add("@EventId", EventId, dbType: DbType.Int32, direction: ParameterDirection.Input); }
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberBonusChangeRecordListViewModel> tmp = await con.QueryAsync<MemberBonusChangeRecordListViewModel>("sp_GetMemberBonusChangeRecordList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberBonusChangeRecordListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //------------------------------------------20181214 YunQiERP 會員點數異動

        //------------------------------------------20181207 YunQiERP 忘記密碼
        //20181207 ---棋
        //記錄到log表
        public async Task<int> InsertMemberForget(string MemberMobile, long token)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Token", token, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertMemberForget", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = -1;
            }
            return ret;
        }

        //20181207 ---棋
        //比對log是否有這筆
        public async Task<int> MemberForget(string MemberMobile, long token)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Token", token, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_MemberForget", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = -1;
            }
            return ret;
        }

        //20181207 ---棋
        //送出更改密碼要求
        public async Task<int> UpdateMemberPassword(string MemberMobile, string Password, long token)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PasswordN", Password, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Token", token, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateMemberPassword", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = -1;
            }
            return ret;
        }

        //------------------------------------------20181207 YunQiERP 忘記密碼

        //------------------------------------------20181205 YunQiERP 業務發展獎金管理
        //20181205 ---棋
        //5.系統在POST Action【MemberBonus/AccountEmployeeDevelopmentBonus】入帳月營運獎金。
        public async Task<int> AccountEmployeeDevelopmentBonus(int Month)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_AccountEmployeeDevelopmentBonus", p, commandType: CommandType.StoredProcedure);
                    //6.系統判斷5成功執行。
                    //7.系統回傳5傳回值。
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = -1;
            }
            return ret;
        }

        //20181205 ---棋
        //5.系統在POST Action【MemberBonus/CaculateEmployeeDevelopmentBonus】計算月營運獎金。
        public async Task<int> CaculateEmployeeDevelopmentBonus(int Month)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_CaculateEmployeeDevelopmentBonus", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                //6a.系統判斷5執行時發生例外。
                //6a - 1.系統傳回 - 1。
                //6a - 2.回主要流程8
                ret = -1;
            }
            return ret;
        }

        //20181205 ---棋
        //9-2.系統在ViewComponent【sp_GetMemberDevelopmentBonusDetailListCount】讀取批發會員獎金記錄總數。
        public async Task<long> GetEmployeeDevelopmentBonusListCount(string EmployeeMobile, int Month)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetEmployeeDevelopmentBonusListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181205 ---棋
        //9-2.系統在ViewComponent【sp_GetMemberDevelopmentBonusDetailListCount】讀取批發會員獎金記錄總數。
        public async Task<long> GetEmployeeDevelopmentBonusDetailListCount(string EmployeeMobile, int Month)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetEmployeeDevelopmentBonusDetailListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //20181203 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取批發會員獎金清單：
        public async Task<List<EmployeeDevelopmentBonusDetailList>> GetEmployeeDevelopmentBonusDetailList(string EmployeeMobile, int Month, int Skip = 0, int RowsPerPage = 10)
        {
            if (EmployeeMobile == null) EmployeeMobile = "";
            List<EmployeeDevelopmentBonusDetailList> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<EmployeeDevelopmentBonusDetailList> tmp = await con.QueryAsync<EmployeeDevelopmentBonusDetailList>("sp_GetEmployeeDevelopmentBonusDetailList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<EmployeeDevelopmentBonusDetailList>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //------------------------------------------20181205 YunQiERP 業務發展獎金管理

        //------------------------------------------YunQiERP 直屬會員發展獎金管理
        //20181203 ---棋
        //5.系統在POST Action【MemberBonus/AccountMemberDevelopmentBonus】入帳月營運獎金。
        public async Task<int> AccountMemberDevelopmentBonus(int Month)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_AccountMemberDevelopmentBonus", p, commandType: CommandType.StoredProcedure);
                    //6.系統判斷5成功執行。
                    //7.系統回傳5傳回值。
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = -1;
            }
            return ret;
        }

        //20181203 ---棋
        //5.系統在POST Action【MemberBonus/CaculateMemberDevelopmentBonus】計算月營運獎金。
        public async Task<int> CaculateMemberDevelopmentBonus(int Month)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_CaculateMemberDevelopmentBonus", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                //6a.系統判斷5執行時發生例外。
                //6a - 1.系統傳回 - 1。
                //6a - 2.回主要流程8
                ret = -1;
            }
            return ret;
        }

        //20181203 ---棋
        //9-2.系統在ViewComponent【sp_GetMemberDevelopmentBonusDetailListCount】讀取批發會員獎金記錄總數。
        public async Task<long> GetMemberDevelopmentBonusListCount(string MemberMobile, int Month)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberDevelopmentBonusListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181203 ---棋
        //9-2.系統在ViewComponent【sp_GetMemberDevelopmentBonusDetailListCount】讀取批發會員獎金記錄總數。
        public async Task<long> GetMemberDevelopmentBonusDetailListCount(string ReferrerMobile, int Month)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberDevelopmentBonusDetailListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //20181203 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取批發會員獎金清單：
        public async Task<List<MemberDevelopmentBonusDetailList>> GetMemberDevelopmentBonusDetailList(string ReferrerMobile, int Month, int Skip = 0, int RowsPerPage = 10)
        {
            if (ReferrerMobile == null) ReferrerMobile = "";
            List<MemberDevelopmentBonusDetailList> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberDevelopmentBonusDetailList> tmp = await con.QueryAsync<MemberDevelopmentBonusDetailList>("sp_GetMemberDevelopmentBonusDetailList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberDevelopmentBonusDetailList>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //------------------------------------------YunQiERP 直屬會員發展獎金管理

        //20181130 ---棋
        //4.系統在Post Action【Member/DeleteMyfavorite】刪除一筆我的最愛資料。
        public async Task<int> DeleteMyfavorite(string MemberMobile, int ProductId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteMyfavorite", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        //------------------------------------------YunQiERP 批發會員獎金設定
        //20181129 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取批發會員獎金清單：
        public async Task<List<MemberBonusDetailListViewModel>> GetMemberBonusDetailList(string ReferrerMobile, int Month, int Skip = 0, int RowsPerPage = 10)
        {
            if (ReferrerMobile == null) ReferrerMobile = "";
            List<MemberBonusDetailListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberBonusDetailListViewModel> tmp = await con.QueryAsync<MemberBonusDetailListViewModel>("sp_GetMemberBonusDetailList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberBonusDetailListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181129 ---棋
        //9-2.系統在ViewComponent【MemberBonusDetailListCount】讀取批發會員獎金記錄總數。
        public async Task<long> GetMemberBonusDetailListCount(string ReferrerMobile, int Month)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberBonusDetailListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //20181129 ---棋
        //9-2.系統在ViewComponent【MemberBonusList】讀取批發會員獎金記錄總數
        public async Task<long> GetMemberBonusListCount(int Month, string ReferrerMobile)
        {
            if (ReferrerMobile == null) ReferrerMobile = "";
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberBonusListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //------------------------------------------ YunQiERP批發會員獎金設定

        public async Task<MemberViewModel> GetMember(string MemberMobile)
        {
            MemberViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberViewModel> tmp = await con.QueryAsync<MemberViewModel>("sp_GetMember", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<MemberViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        //public async Task<int> UpdateMember(string MemberMobile, string MemberName, string NickName, byte sex,
        //                                    DateTime Birthday, string eMail, string LineId, string Phone, string ContactAddress, string ID,
        //                                    string Bank, string Branch, string AccountNunber, string AccountName)
        public async Task<int> UpdateMember(string MemberMobile, string MemberName, string NickName, byte sex,
                                            DateTime? Birthday, string eMail, string LineId, string Phone, string ContactAddress)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@NickName", NickName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sex", sex, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    p.Add("@Birthday", Birthday, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add("@eMail", eMail, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@LineId", LineId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Phone", Phone, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ContactAddress", ContactAddress, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@ID", ID, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@Bank", Bank, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@Branch", Branch, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@AccountNunber", AccountNunber, dbType: DbType.String, direction: ParameterDirection.Input);
                    //p.Add("@AccountName", AccountName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateMember", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }
        public async Task<int> ChangeMemberBonus(string MemberMobile,string Memo, int Bonus )
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Memo", Memo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Bonus", Bonus, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_ChangeMemberBonus", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");

                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<int> ChangeMemberBonusToMoney(int RecordId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@RecordId", RecordId, dbType: DbType.String, direction: ParameterDirection.Input);
                   
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_ChangeMemberBonusToMoney", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }
        public async Task<int> UpdateMemberLevel(string MemberMobile, int MemberLevelId, DateTime? VipApplyDate = null, DateTime? VipDate = null, string ReferrerMobile = "")
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberLevelId", MemberLevelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@VipApplyDate", VipApplyDate, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add("@VipDate", VipDate, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateMemberLevel", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        //20181212更新 ---棋
        public async Task<int> UpdateMemberLevelCart(string FileName, byte[] PictureContent, string PictureType, string MemberMobile, int MemberLevelId, string ID, string Bank, string Branch, string AccountNunber, string AccountName, DateTime? VipApplyDate = null, DateTime? VipDate = null, string ReferrerMobile = "")
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@FileName", FileName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@PictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberLevelId", MemberLevelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@VipApplyDate", VipApplyDate, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add("@VipDate", VipDate, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ID", ID, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Bank", Bank, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Branch", Branch, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@AccountNunber", AccountNunber, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@AccountName", AccountName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateMemberLevelCart", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<List<MemberLevelViewModel>> GetMembevLevel()
        {
            List<MemberLevelViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberLevelViewModel> tmp = await con.QueryAsync<MemberLevelViewModel>("sp_GetMemberLevel", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberLevelViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<long> GetMemberListCount(string MemberMobile = "", string MemberName = "", string ReferrerMobile = "", int MemberLevelId = 0, int Enabled = 10)
        {
            if (MemberMobile == null) MemberMobile = "";
            if (MemberName == null) MemberName = "";
            if (ReferrerMobile == null) ReferrerMobile = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberLevelId", MemberLevelId, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    p.Add("@Enabled", Enabled, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<MemberViewModel>> GetMemberList(string MemberMobile = "", string MemberName = "", string ReferrerMobile = "", int MemberLevelId = 0, int Enabled = 10, int Skip = 0, int RowsPerPage = 10)
        {
            if (MemberMobile == null) MemberMobile = "";
            if (MemberName == null) MemberName = "";
            if (ReferrerMobile == null) ReferrerMobile = "";
            List<MemberViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberLevelId", MemberLevelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@@Enabled", Enabled, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberViewModel> tmp = await con.QueryAsync<MemberViewModel>("sp_GetMemberList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateMemberEnabled(string MemberMobile, byte Enabled)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Enabled", Enabled, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateMemberEnabled", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<int> UpdateMemberReferrer(List<UpdateMemberReferrerModel> listUMRM)
        {
            int ret = 0;
            string sql1 = @"Update t_Member Set ReferrerMobile=@ReferrerMobile Where MemberMobile=@MemberMobile";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    await con.OpenAsync();
                    await con.ExecuteAsync(sql1, listUMRM, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 3;
            }
            return ret;
        }

        public async Task<int> ValidateReferrerMobile(string ReferrerMobile)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_ValidateReferrerMobile", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 3;
            }
            return ret;
        }
        public async Task<int> InsertMemberFavorite(string MemberMobile, int ProductId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertMemberFavorite", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<int> UsedMemberBonus(string MemberMobile , int Bonus, int UsedBonus ,int? EventId = 5)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Bonus", Bonus, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@UsedBonus", UsedBonus, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@EventId", EventId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_MemberUsedBonus", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");

                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }
        public async Task<long> GetMemberOrderBonusListCount(string MemberMobile)
        {            
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberOrderBonusListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<long>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = -1;
            }
            return ret;
        }
        public async Task<long> GetMemberOrderBonusSum(string MemberMobile)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberOrderBonusSum", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<long>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = -1;
            }
            return ret;
        }
        public async Task<List<MemberOrderBonusListViewModel>> GetMemberOrderBonusList(string MemberMobile, int Skip = 0, int RowsPerPage = 1000)
        {            
            List<MemberOrderBonusListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);                   
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberOrderBonusListViewModel> tmp = await con.QueryAsync<MemberOrderBonusListViewModel>("sp_GetMemberOrderBonusList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberOrderBonusListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<long> GetMemberFavoriteListCount(string MemberMobile, string Product)
        {
            if (Product == null) Product = "";
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberFavoriteListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<long>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = -1;
            }
            return ret;
        }

        public async Task<List<ProductListViewModel>> GetMemberFavoriteList(string MemberMobile, string Product, int Skip = 0, int RowsPerPage = 1000)
        {
            if (Product == null) Product = "";
            List<ProductListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductListViewModel> tmp = await con.QueryAsync<ProductListViewModel>("sp_GetMemberFavoriteList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertMemberCarts(List<MemberCartsViewModel> carts)
        {
            // 會在InsertMemberCarts依參數carts之Count呼叫多次sp_InsertMemberCarts，並將多次呼叫整理為一Tranction。
            int ret = 0;
            DynamicParameters p;
            DateTime dt = DateTime.Now;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    await con.OpenAsync();
                    using (var trans = con.BeginTransaction())
                    {
                        foreach (MemberCartsViewModel item in carts)
                        {
                            p = new DynamicParameters();
                            p.Add("@MemberMobile", item.MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                            p.Add("@ProductId", item.ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                            p.Add("@ProducSizeId", item.ProducSizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                            p.Add("@ProductColorId", item.ProductColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                            p.Add("@ProductSize", item.ProducSizeId, dbType: DbType.String, direction: ParameterDirection.Input);
                            p.Add("@ProductColor", item.ProductColorId, dbType: DbType.String, direction: ParameterDirection.Input);
                            p.Add("@Quantity", item.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
                            p.Add("@UpdateTime", dt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                            p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                            await con.ExecuteAsync("sp_InsertMemberCarts", p, commandType: CommandType.StoredProcedure, transaction: trans);
                        }
                        try
                        {
                            trans.Commit();
                        }
                        catch (Exception exi)
                        {
                            trans.Rollback();
                            ret = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<List<CartListViewModel>> GetCartList(string MemberMobile)
        {
            List<CartListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<CartListViewModel> tmp = await con.QueryAsync<CartListViewModel>("sp_GetCartList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<CartListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<int> DeleteMemberCart(string MemberMobile, int ProductId, int ProducSizeId, int ProductColorId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProducSizeId", ProducSizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductColorId", ProductColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteMemberCart", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<int> DeleteMemberCarts(List<MemberCartsViewModel> carts)
        {
            // 會在InsertMemberCarts依參數carts之Count呼叫多次sp_InsertMemberCarts，並將多次呼叫整理為一Tranction。
            int ret = 0;
            DynamicParameters p;
            DateTime dt = DateTime.Now;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    await con.OpenAsync();
                    using (var trans = con.BeginTransaction())
                    {
                        foreach (MemberCartsViewModel item in carts)
                        {
                            p = new DynamicParameters();
                            p.Add("@MemberMobile", item.MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                            p.Add("@ProductId", item.ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                            p.Add("@ProducSizeId", item.ProducSizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                            p.Add("@ProductColorId", item.ProductColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                            p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                            await con.ExecuteAsync("sp_DeleteMemberCart", p, commandType: CommandType.StoredProcedure, transaction: trans);
                        }
                        try
                        {
                            trans.Commit();
                        }
                        catch (Exception exi)
                        {
                            trans.Rollback();
                            ret = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<int> DeleteAllMemberCarts(string MemberMobile)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteAllMemberCarts", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<int> UpdateMemberCart(string MemberMobile, int ProductId, int ProducSizeId, int ProductColorId, int ProducSizeIdN, int ProductColorIdN, string ProductSize, string ProductColor, int QuantityN)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProducSizeId", ProducSizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductColorId", ProductColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProducSizeIdN", ProducSizeIdN, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductColorIdN", ProductColorIdN, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductSize", ProductSize, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductColor", ProductColor, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@QuantityN", QuantityN, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateMemberCart", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<int> UpdateOrderState(string OrderId, byte OrderStateId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@OrderStateId", OrderStateId, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateOrderState", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 1;
            }
            return ret;
        }

        public async Task<long> GetMyfollowerCount(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile)
        {
            if (MemberMobile == null) MemberMobile = "";
            if (ReferrerMobile == null) ReferrerMobile = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMyfollowerCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<MemberViewModel>> GetMyfollowerList(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile, int Skip, int RowsPerPage)
        {
            if (MemberMobile == null) MemberMobile = "";
            if (ReferrerMobile == null) ReferrerMobile = "";
            List<MemberViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberViewModel> tmp = await con.QueryAsync<MemberViewModel>("sp_GetMyfollowerList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }
    }
}