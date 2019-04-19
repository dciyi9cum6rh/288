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
    public class SalaryRepository : ISalaryRepository
    {
        public string constr { get; set; }
        //public SqlConnection con { get; set; }

        public SalaryRepository()
        {
            constr = "";
            //con = new SqlConnection(constr);
        }

        public SalaryRepository(string connection)
        {
            constr = connection;
            //con = new SqlConnection(constr);
        }

        //------------------------------------------20181210 YunQiERP 會計總帳
        //20181203 ---棋
        //9-5系統在ViewComponent【MemberBonusDetailListViewComponent】讀取批發會員獎金清單：
        public async Task<List<GetLedgerMonthListViewModel>> GetLedgerMonthList(int Month)
        {
            List<GetLedgerMonthListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<GetLedgerMonthListViewModel> tmp = await con.QueryAsync<GetLedgerMonthListViewModel>("sp_GetLedgerMonthList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<GetLedgerMonthListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //該月總收入
        public async Task<long> GetLedgerMonthAddMoney(int Month)
        {
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetLedgerMonthAddMoney", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //--該月總支出
        public async Task<long> GetLedgerMonthMinusMoney(int Month)
        {
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetLedgerMonthMinusMoney", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //------------------------------------------20181210 YunQiERP 會計總帳

        //------------------------------------------20181210 YunQiERP 分類帳
        //20181213 ---棋
        //9-2.系統在ViewComponent【GetLedgerListCount】讀取批發會員獎金記錄總數。
        public async Task<long> GetLedgerListCount(string AccountingSubject, int Month)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingSubject", AccountingSubject, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetLedgerListCount", p, commandType: CommandType.StoredProcedure);
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
        public async Task<List<LedgerListViewModel>> GetLedgerList(string AccountingSubject, int Month, int Skip = 0, int RowsPerPage = 10)
        {
            if (AccountingSubject == null) AccountingSubject = "";
            List<LedgerListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingSubject", AccountingSubject, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<LedgerListViewModel> tmp = await con.QueryAsync<LedgerListViewModel>("sp_GetLedgerList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<LedgerListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181213 ---棋
        //9-2.系統在ViewComponent【GetLedgerListCount】新增會計分類。
        public async Task<long> InsertLedger(string AccountingId, int Month, string InvoiceId, string LedgerDescription, long Money)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingId", AccountingId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@InvoiceId", InvoiceId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@LedgerDescription", LedgerDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Money", Money, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_InsertLedger", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //20181213 ---棋
        //9-2.系統在ViewComponent【GetLedgerListCount】更新會計分類。
        public async Task<long> UpdateLedger(string AccountingId, int LedgerId, long Money, string InvoiceId, string LedgerDescription, int Month)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingIdN", AccountingId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@LedgerId", LedgerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@MoneyN", Money, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@InvoiceIdN", InvoiceId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@LedgerDescriptionN", LedgerDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MonthN", Month, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_UpdateLedger", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //20181213 ---棋
        //9-2.系統在ViewComponent【GetLedgerListCount】刪除會計分類。
        public async Task<long> DeleteLedger(string AccountingId, int LedgerId)
        {
            long ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingId", AccountingId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@LedgerId", LedgerId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_DeleteLedger", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        //------------------------------------------20181210 YunQiERP 分類帳

        //------------------------------------------20181210 YunQiERP 薪資類別管理
        //20181205 ---棋
        //5.系統在POST Action【MemberBonus/AccountEmployeeDevelopmentBonus】入帳月營運獎金。
        public async Task<int> AccountSalary(int Month)
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
                    await con.ExecuteAsync("sp_AccountSalary", p, commandType: CommandType.StoredProcedure);
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
        public async Task<List<SalaryClassListViewModel>> GetSalaryClassList()
        {
            List<SalaryClassListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<SalaryClassListViewModel> tmp = await con.QueryAsync<SalaryClassListViewModel>("sp_GetSalaryClassList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<SalaryClassListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        //20181205 ---棋
        public async Task<List<SalaryMonthEmployeeDetailListViewModel>> GetSalaryMonthEmployeeDetailList(string EmployeeMobile, int Month, int Skip, int RowsPerPage)
        {
            List<SalaryMonthEmployeeDetailListViewModel> ret = null;
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
                    IEnumerable<SalaryMonthEmployeeDetailListViewModel> tmp = await con.QueryAsync<SalaryMonthEmployeeDetailListViewModel>("sp_GetSalaryMonthEmployeeDetailList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<SalaryMonthEmployeeDetailListViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //20181205 ---棋
        public async Task<int> InsertSalary(int Month, string EmployeeMobile, List<SalaryDataModel> SalaryDatas)
        {
            string sqlDelete = @"Delete [dbo].[t_Salary] where [Month]=@Month and EmployeeMobile=@EmployeeMobile";
            string sqlInsert2 = @"Insert into [dbo].[t_Salary] ([Month],EmployeeMobile,SalaryClassId,Salary) values(@Month,@EmployeeMobile,@SalaryClassId,@Salary)";

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
                        p = new DynamicParameters();
                        p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                        await con.ExecuteAsync(sqlDelete, p, commandType: CommandType.Text, transaction: trans);
                        await con.ExecuteAsync(sqlInsert2, SalaryDatas, commandType: CommandType.Text, transaction: trans);
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

        //20181205 ---棋
        public async Task<int> GetDeleteSalary(string EmployeeMobile, int Month)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteSalary", p, commandType: CommandType.StoredProcedure);
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

        //20181205 ---棋
        public async Task<List<GetEmployeeBaseSalaryViewModel>> GetEmployeeBaseSalary(string EmployeeMobile)
        {
            List<GetEmployeeBaseSalaryViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<GetEmployeeBaseSalaryViewModel> tmp = await con.QueryAsync<GetEmployeeBaseSalaryViewModel>("sp_GetEmployeeBaseSalary", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<GetEmployeeBaseSalaryViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        //------------------------------------------20181210 YunQiERP 薪資類別管理

        public async Task<long> GetSalaryClassCount(string SalaryClass)
        {
            if (SalaryClass == null) SalaryClass = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@SalaryClass", SalaryClass, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetSalaryClassCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<SalaryClassListViewModel>> GetSalaryClassList(string SalaryClass, int Skip, int RowsPerPage)
        {
            if (SalaryClass == null) SalaryClass = "";
            List<SalaryClassListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@SalaryClass", SalaryClass, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<SalaryClassListViewModel> tmp = await con.QueryAsync<SalaryClassListViewModel>("sp_GetSalaryClassList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<SalaryClassListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertSalaryClass(string SalaryClass, int ClassSalary, string SalaryClassDescription)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@SalaryClass", SalaryClass, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ClassSalary", ClassSalary, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@SalaryClassDescription", SalaryClassDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertSalaryClass", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> UpdateSalaryClass(string SalaryClass, int ClassSalary, string SalaryClassDescription, int SalaryClassId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@SalaryClass", SalaryClass, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ClassSalary", ClassSalary, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@SalaryClassDescription", SalaryClassDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@SalaryClassId", SalaryClassId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateSalaryClass", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteSalaryClass(int SalaryClassId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@SalaryClassId", SalaryClassId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteSalaryClass", p, commandType: CommandType.StoredProcedure);
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
    }
}