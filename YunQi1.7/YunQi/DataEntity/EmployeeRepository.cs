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
    public class EmployeeRepository : IEmployeeRepository
    {
        public string constr { get; set; }
        //public SqlConnection con { get; set; }

        public EmployeeRepository()
        {
            constr = "";
            //con = new SqlConnection(constr);
        }

        public EmployeeRepository(string connection)
        {
            constr = connection;
            //con = new SqlConnection(constr);
        }

        //------------------------------------------20181220 YunQiERP 留言板管理
        //20181220 ---棋
        //9-2.系統在ViewComponent【GetMailCenterMessageCount】讀取訊息總數。
        public async Task<long> GetMessageManagementCount(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string MemberMobile, string NickName)
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
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@NickName", NickName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMessageManagementCount", p, commandType: CommandType.StoredProcedure);
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
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取訊息清單：
        public async Task<List<MessageManagementListViewModel>> GetMessageManagementList(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string MemberMobile, string NickName, int Skip = 0, int RowsPerPage = 10)
        {
            if (MessageValue == null) MessageValue = "";
            List<MessageManagementListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@VersionId", VersionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@MessageValue", MessageValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@NickName", NickName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MessageManagementListViewModel> tmp = await con.QueryAsync<MessageManagementListViewModel>("sp_GetMessageManagementList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MessageManagementListViewModel>();
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
        //9-2.系統在ViewComponent【GetMailCenterMessageCount】讀取訊息總數。
        public async Task<long> GetReplyMessageManagementCount(int MessageId)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MessageId", MessageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetReplyMessageManagementCount", p, commandType: CommandType.StoredProcedure);
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
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取訊息清單：
        public async Task<List<ReplyMessageManagementDataListviewModel>> GetReplyMessageManagementList(int MessageId, int Skip, int RowsPerPage)
        {
            List<ReplyMessageManagementDataListviewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MessageId", MessageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ReplyMessageManagementDataListviewModel> tmp = await con.QueryAsync<ReplyMessageManagementDataListviewModel>("sp_GetReplyMessageManagementList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ReplyMessageManagementDataListviewModel>();
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
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】上傳版規圖檔：
        public async Task<int> UpdateMemberLevelCart(int VersionId, byte[] PictureContent, string PictureType, string FileName)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@VersionId", VersionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@VersionRulePictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@VersionRulePictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@VersionRuleFileName", FileName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateVersionRule", p, commandType: CommandType.StoredProcedure);
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

        //20181221 ---棋
        //9-2.系統在ViewComponent【GetMailCenterMessageCount】讀取留言板版圖片
        public async Task<GetImgVersionRuleViewModel> GetCagegoryImage(int VersionId)
        {
            GetImgVersionRuleViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@VersionId", VersionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<GetImgVersionRuleViewModel> tmp = await con.QueryAsync<GetImgVersionRuleViewModel>("sp_GetVersionRuleList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<GetImgVersionRuleViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        //20181221 ---棋
        //9-2.系統在ViewComponent【GetMailCenterMessageCount】讀取留言板版別。
        public async Task<List<VersionListViewModel>> GetVersion()
        {
            List<VersionListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<VersionListViewModel> tmp = await con.QueryAsync<VersionListViewModel>("sp_GetVersionList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<VersionListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181221 ---棋
        //9-2.系統在ViewComponent【GetMailCenterMessageCount】新增回復內容。
        public async Task<long> InsertReplyMessageManagement(int MessageId, string ReplyMessageValue, string ReplyMobile)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MessageId", MessageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ReplyMessageValue", ReplyMessageValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ReplyMobile", ReplyMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_InsertReplyMessageManagement", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181221 ---棋
        //9-2.系統在ViewComponent【GetMailCenterMessageCount】讀取刪除留言。
        public async Task<long> DeleteMessageManagement(int MessageId)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MessageId", MessageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_DeleteMessageManagement", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181221 ---棋
        //9-2.系統在ViewComponent【GetMailCenterMessageCount】讀取刪除回復留言。
        public async Task<long> DeleteReplyMessageManagement(int ReplyMessageId)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ReplyMessageId", ReplyMessageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_DeleteReplyMessageManagement", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //------------------------------------------20181220 YunQiERP 留言板管理

        //------------------------------------------20181217 YunQiERP 訊息中心
        //20181217 ---棋
        //9-2.系統在ViewComponent【GetMailCenterMessageCount】讀取訊息總數。
        public async Task<long> GetMailCenterMessageCount(int MemberLevelId, string MessageValue, DateTime? sDate, DateTime? eDate)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberLevelId", MemberLevelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@MessageValue", MessageValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMailCenterMessageCount", p, commandType: CommandType.StoredProcedure);
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
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取訊息清單：
        public async Task<List<GetMailCenterMessageListViewModel>> GetMailCenterMessageList(int MemberLevelId, string MessageValue, DateTime? sDate, DateTime? eDate, int Skip = 0, int RowsPerPage = 10)
        {
            if (MessageValue == null) MessageValue = "";
            List<GetMailCenterMessageListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberLevelId", MemberLevelId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@MessageValue", MessageValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<GetMailCenterMessageListViewModel> tmp = await con.QueryAsync<GetMailCenterMessageListViewModel>("sp_GetMailCenterMessageList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<GetMailCenterMessageListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181217 ---棋
        //9-2.系統在ViewComponent【GetMailCenterMessageCount】讀取訊息總數。
        public async Task<int> DeleteMailCenterMessage(int MessageId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MessageId", MessageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<int> tmp = await con.QueryAsync<int>("sp_DeleteMailCenterMessage", p, commandType: CommandType.StoredProcedure);
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
        //新增後台訊息中心
        public async Task<int> InsertMailCenterMessage(List<MailCenterDataModel> MailCenter)
        {
            string sqlDelete = @"Insert into t_MailCenter(MessageId,MessageTime,MessageValue,MemberLevelId,EmployeeMobile,MessageTitle) Values(@MessageId,@MessageTime,@MessageValue,@MemberLevelId,@EmployeeMobile,@MessageTitle)";
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    await con.OpenAsync();
                    using (var trans = con.BeginTransaction())
                    {
                        await con.ExecuteAsync(sqlDelete, MailCenter, commandType: CommandType.Text, transaction: trans);
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

        //20181218 ---棋
        //找目前後臺訊息比數
        public async Task<int> GetMailCenterTop1()
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<int> tmp = await con.QueryAsync<int>("sp_GetMailCenterTop1", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //------------------------------------------20181217 YunQiERP 訊息中心

        //------------------------------------------20181210 YunQiERP 薪資類別管理
        //20181210 ---棋
        //9-2.系統在ViewComponent【sp_GetMemberDevelopmentBonusDetailListCount】讀取批發會員獎金記錄總數。
        public async Task<long> GetEmployeeMonthSalaryListCount(string EmployeeMobile, int Month)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile ", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month ", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetEmployeeMonthSalaryListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -3;
            }
            return ret;
        }

        //20181210 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取批發會員獎金清單：
        public async Task<List<EmployeeMonthSalaryViewModel>> GetEmployeeMonthSalaryList(string EmployeeMobile, int Month, int Skip = 0, int RowsPerPage = 10)
        {
            if (EmployeeMobile == null) EmployeeMobile = "";
            List<EmployeeMonthSalaryViewModel> ret = null;
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
                    IEnumerable<EmployeeMonthSalaryViewModel> tmp = await con.QueryAsync<EmployeeMonthSalaryViewModel>("sp_GetEmployeeMonthSalaryList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<EmployeeMonthSalaryViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //------------------------------------------20181210 YunQiERP 薪資類別管理

        public async Task<int> EmployeeLogin(string EmployeeMobile, string Password)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.AnsiString, direction: ParameterDirection.Input);
                    p.Add("@Password", Password, dbType: DbType.AnsiString, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_EmployeeLogin", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> InsertEmployee(string EmployeeMobile, string Password, int PositionId, string Name, DateTime Birthday, DateTime Duedate, byte sex, int BaseSalary, string ID, string EmergencyContact, string EmergencyContactPhone, string ContactPhone, string ContactAddress, string eMail, DateTime UpdateTime, string UpdateEmployeeMobile, string LineId = "")
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String);
                    p.Add("@Password", Password, dbType: DbType.String);
                    p.Add("@PositionId", PositionId, dbType: DbType.Int32);
                    p.Add("@Name", Name, dbType: DbType.String);
                    p.Add("@Birthday", Birthday, dbType: DbType.Date);
                    p.Add("@Duedate", Duedate, dbType: DbType.Date);
                    p.Add("@sex", sex, dbType: DbType.Byte);
                    p.Add("@BaseSalary", BaseSalary, dbType: DbType.Int32);
                    p.Add("@ID", ID, dbType: DbType.String);
                    p.Add("@EmergencyContact", EmergencyContact, dbType: DbType.String);
                    p.Add("@EmergencyContactPhone", EmergencyContactPhone, dbType: DbType.String);
                    p.Add("@ContactPhone", ContactPhone, dbType: DbType.String);
                    p.Add("@ContactAddress", ContactAddress, dbType: DbType.String);
                    p.Add("@eMail", eMail, dbType: DbType.String);
                    p.Add("@LineId", LineId, dbType: DbType.String);
                    p.Add("@UpdateTime", UpdateTime, dbType: DbType.DateTime);
                    p.Add("@UpdateEmployeeMobile", UpdateEmployeeMobile, dbType: DbType.String);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertEmployee", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception)
            {
                ret = 1;
            }
            return ret;
        }

        public async Task<List<int>> GetEmployeeRights(string EmployeeMobile)
        {
            List<int> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<int> tmp = await con.QueryAsync<int>("sp_GetEmployeeRights", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<int>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<long> GetDepartmentListCount(int DepartmentId, string Department = "")
        {
            if (Department == null) Department = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@DepartmentId", DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Department", Department, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    //var tmp = await con.QueryMultipleAsync("sp_GetMemberCount", p, commandType: CommandType.StoredProcedure);
                    //ret = tmp.Read<long>().FirstOrDefault();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetDepartmentListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<DepartmentListViewModel>> GetDepartmentList(int DepartmentId, string Department = "", int Skip = 0, int RowsPerPage = 10)
        {
            if (Department == null) Department = "";
            List<DepartmentListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@DepartmentId", DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Department", Department, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<DepartmentListViewModel> tmp = await con.QueryAsync<DepartmentListViewModel>("sp_GetDepartmentList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<DepartmentListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<List<DepartmentLevelPathViewModel>> GetDepartmentLevelPath(int DepartmentId)
        {
            List<DepartmentLevelPathViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@DepartmentId", DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<DepartmentLevelPathViewModel> tmp = await con.QueryAsync<DepartmentLevelPathViewModel>("sp_GetDepartmentLevelPath", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<DepartmentLevelPathViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertDepartment(int ParentDepartmentId, string Department, string DepartmentDescription)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ParentDepartmentId", ParentDepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Department", Department, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@DepartmentDescription", DepartmentDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertDepartment", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> UpdateDepartment(int DepartmentId, string Department, string DepartmentDescription)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@DepartmentId", DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Department", Department, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@DepartmentDescription", DepartmentDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateDepartment", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteDepartment(int DepartmentId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@DepartmentId", DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteDepartment", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> InsertPosition(int DepartmentId, string Position, string PositionDescription)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@DepartmentId", DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Position", Position, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PositionDescription", PositionDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertPosition", p, commandType: CommandType.StoredProcedure);
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

        public async Task<long> GetPositionListCount(int DepartmentId)
        {
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@DepartmentId", DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetPositionListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<PositionListViewModel>> GetPositionList(int DepartmentId, int Skip, int RowsPerPage)
        {
            List<PositionListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@DepartmentId", DepartmentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<PositionListViewModel> tmp = await con.QueryAsync<PositionListViewModel>("sp_GetPositionList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<PositionListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdatePosition(int PositionId, string Position, string PositionDescription)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PositionId", PositionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Position", Position, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PositionDescription", PositionDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdatePosition", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeletePosition(int PositionId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PositionId", PositionId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeletePosition", p, commandType: CommandType.StoredProcedure);
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

        public async Task<long> GetEmployeeListCount(string Department, string Position, string EmployeeName)
        {
            if (Department == null) Department = "";
            if (Position == null) Position = "";
            if (EmployeeName == null) EmployeeName = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Department", Department, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Position", Position, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@EmployeeName", EmployeeName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetEmployeeListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<EmployeeListViewModel>> GetEmployeeList(string Department, string Position, string EmployeeName, int Skip, int RowsPerPage)
        {
            if (Department == null) Department = "";
            if (Position == null) Position = "";
            if (EmployeeName == null) EmployeeName = "";
            List<EmployeeListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Department", Department, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Position", Position, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@EmployeeName", EmployeeName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<EmployeeListViewModel> tmp = await con.QueryAsync<EmployeeListViewModel>("sp_GetEmployeeList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<EmployeeListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateEmployee(string EmployeeMobile, string Name, DateTime Birthday, DateTime Duedate, byte sex, int BaseSalary, string ID, string EmergencyContact, string EmergencyContactPhone, string ContactPhone, string ContactAddress, string eMail, DateTime UpdateTime, string UpdateEmployeeMobile, string LineId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String);
                    p.Add("@Name", Name, dbType: DbType.String);
                    p.Add("@Birthday", Birthday, dbType: DbType.Date);
                    p.Add("@Duedate", Duedate, dbType: DbType.Date);
                    p.Add("@sex", sex, dbType: DbType.Byte);
                    p.Add("@BaseSalary", BaseSalary, dbType: DbType.Int32);
                    p.Add("@ID", ID, dbType: DbType.String);
                    p.Add("@EmergencyContact", EmergencyContact, dbType: DbType.String);
                    p.Add("@EmergencyContactPhone", EmergencyContactPhone, dbType: DbType.String);
                    p.Add("@ContactPhone", ContactPhone, dbType: DbType.String);
                    p.Add("@ContactAddress", ContactAddress, dbType: DbType.String);
                    p.Add("@eMail", eMail, dbType: DbType.String);
                    p.Add("@LineId", LineId, dbType: DbType.String);
                    p.Add("@UpdateTime", UpdateTime, dbType: DbType.DateTime);
                    p.Add("@UpdateEmployeeMobile", UpdateEmployeeMobile, dbType: DbType.String);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateEmployee", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 2;
            }
            return ret;
        }

        public async Task<int> DeleteEmployee(string EmployeeMobile)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteEmployee", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 2;
            }
            return ret;
        }

        public async Task<PositionViewModel> ValidatePosition(string Position)
        {
            PositionViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Position", Position, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<PositionViewModel> tmp = await con.QueryAsync<PositionViewModel>("sp_ValidatePosition", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<PositionViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateEmployeePosition(string EmployeeMobile, string Position, DateTime UpdateTime, string UpdateEmployeeMobile)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String);
                    p.Add("@Position", Position, dbType: DbType.String);
                    p.Add("@UpdateTime", UpdateTime, dbType: DbType.DateTime);
                    p.Add("@UpdateEmployeeMobile", UpdateEmployeeMobile, dbType: DbType.String);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateEmployeePosition", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception)
            {
                ret = 1;
            }
            return ret;
        }

        public async Task<List<EmplyoeeRightViewModel>> GetEmployeeRight(string EmployeeMobile)
        {
            List<EmplyoeeRightViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<EmplyoeeRightViewModel> tmp = await con.QueryAsync<EmplyoeeRightViewModel>("sp_GetEmployeeRight", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<EmplyoeeRightViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateEmployeeRights(string EmployeeMobile, string rights)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String);
                    p.Add("@rights", rights, dbType: DbType.String);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateEmployeeRights", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception)
            {
                ret = 1;
            }
            return ret;
        }

        public async Task<int> UpdateEmployeePassword(string EmployeeMobile, string OldPassword, string NewPassword, DateTime UpdateTime, string UpdateEmployeeMobile)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String);
                    p.Add("@OldPassword", OldPassword, dbType: DbType.String);
                    p.Add("@NewPassword", NewPassword, dbType: DbType.String);
                    p.Add("@UpdateTime", UpdateTime, dbType: DbType.DateTime);
                    p.Add("@UpdateEmployeeMobile", UpdateEmployeeMobile, dbType: DbType.String);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateEmployeePassword", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception)
            {
                ret = 1;
            }
            return ret;
        }
    }
}