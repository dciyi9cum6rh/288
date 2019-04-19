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
    public class AccountingRepository : IAccountingRepository
    {
        public string constr { get; set; }
        //public SqlConnection con { get; set; }

        public AccountingRepository()
        {
            constr = "";
            //con = new SqlConnection(constr);
        }

        public AccountingRepository(string connection)
        {
            constr = connection;
            //con = new SqlConnection(constr);
        }

        public async Task<long> GetAccountingCount(string AccountingSubject)
        {
            if (AccountingSubject == null) AccountingSubject = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingSubject", AccountingSubject, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetAccountingCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<AccountingListViewModel>> GetAccountingList(string AccountingSubject, int Skip, int RowsPerPage)
        {
            if (AccountingSubject == null) AccountingSubject = "";
            List<AccountingListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingSubject", AccountingSubject, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<AccountingListViewModel> tmp = await con.QueryAsync<AccountingListViewModel>("sp_GetAccountingList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<AccountingListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertAccounting(string AccountingId, string AccountingSubject, string AccountingDescription)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingId", AccountingId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@AccountingSubject", AccountingSubject, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@AccountingDescription", AccountingDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertAccounting", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> UpdateAccounting(string AccountingId, string AccountingSubject, string AccountingDescription)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingId", AccountingId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@AccountingSubject", AccountingSubject, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@AccountingDescription", AccountingDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateAccounting", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteAccounting(string AccountingId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@AccountingId", AccountingId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteAccounting", p, commandType: CommandType.StoredProcedure);
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
    }
}