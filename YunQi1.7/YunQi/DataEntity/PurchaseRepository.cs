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
    public class PurchaseRepository : IPurchaseRepository
    {
        public string constr { get; set; }
        //public SqlConnection con { get; set; }

        public PurchaseRepository()
        {
            constr = "";
            //con = new SqlConnection(constr);
        }

        public PurchaseRepository(string connection)
        {
            constr = connection;
        }

        public async Task<long> GetPurchaseListCount(DateTime? sDate, DateTime? eDate, string Product = "", string PurchaseId = "")
        {
            if (Product == null) Product = "";
            if (PurchaseId == null) PurchaseId = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetPurchaseListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<PurchaseListViewModel>> GetPurchaseList(DateTime? sDate, DateTime? eDate, int Skip, int RowsPerPage, string Product = "", string PurchaseId = "")
        {
            if (Product == null) Product = "";
            if (PurchaseId == null) PurchaseId = "";
            List<PurchaseListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<PurchaseListViewModel> tmp = await con.QueryAsync<PurchaseListViewModel>("sp_GetPurchaseList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<PurchaseListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<long> GetPurchaseDetailListCount(string PurchaseId)
        {
            if (PurchaseId == null) PurchaseId = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetPurchaseDetailListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<PurchaseDetailListViewModel>> GetPurchaseDetailList(string PurchaseId, int Skip, int RowsPerPage)
        {
            List<PurchaseDetailListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<PurchaseDetailListViewModel> tmp = await con.QueryAsync<PurchaseDetailListViewModel>("sp_GetPurchaseDetailList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<PurchaseDetailListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<List<CurrencyViewModel>> GetCurrency()
        {
            List<CurrencyViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<CurrencyViewModel> tmp = await con.QueryAsync<CurrencyViewModel>("sp_GetCurrency", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<CurrencyViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<PurchaseIdViewModel> GetNewPurchaseId(DateTime PurchaseTime)
        {
            PurchaseIdViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PurchaseTime", PurchaseTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<PurchaseIdViewModel> tmp = await con.QueryAsync<PurchaseIdViewModel>("sp_GetNewPurchaseId", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<PurchaseIdViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertPurchase(string PurchaseId, DateTime PurchaseTime, string UpdateEmployeeMobile,
            int CurrencyId, decimal ExchangeRate, decimal Freight, decimal miscellaneous, decimal ProductFee)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PurchaseTime", PurchaseTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@UpdateEmployeeMobile", UpdateEmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@CurrencyId", CurrencyId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ExchangeRate", ExchangeRate, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@Freight", Freight, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@miscellaneous", miscellaneous, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@ProductFee", ProductFee, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertPurchase", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> InsertPurchaseDetail(string PurchaseId, int ProductId, int ProducSizeId, int ProductColorId, decimal PurchasePrice,
            int Quantity, decimal ExchangeRate)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProducSizeId", ProducSizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductColorId", ProductColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@PurchasePrice", PurchasePrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@Quantity", Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ExchangeRate", ExchangeRate, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertPurchaseDetail", p, commandType: CommandType.StoredProcedure);
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

        public async Task<PurchaseListViewModel> GetPurchase(string PurchaseId)
        {
            PurchaseListViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<PurchaseListViewModel> tmp = await con.QueryAsync<PurchaseListViewModel>("sp_GetPurchase", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<PurchaseListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdatePurchase(string PurchaseId, DateTime PurchaseTime, string UpdateEmployeeMobile,
            int CurrencyId, decimal ExchangeRate, decimal Freight, decimal miscellaneous, decimal ProductFee)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PurchaseTime", PurchaseTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@UpdateEmployeeMobile", UpdateEmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@CurrencyId", CurrencyId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ExchangeRate", ExchangeRate, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@Freight", Freight, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@miscellaneous", miscellaneous, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@ProductFee", ProductFee, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdatePurchase", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeletePurchase(string PurchaseId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeletePurchase", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeletePurchaseDetail(string PurchaseId, int PurchaseDetailId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@PurchaseId", PurchaseId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PurchaseDetailId", PurchaseDetailId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeletePurchaseDetail", p, commandType: CommandType.StoredProcedure);
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