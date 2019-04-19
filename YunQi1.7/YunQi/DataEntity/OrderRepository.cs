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
    public class OrderRepository : IOrderRepository
    {
        public string constr { get; set; }
        //public SqlConnection con { get; set; }

        public OrderRepository()
        {
            constr = "";
            //con = new SqlConnection(constr);
        }

        public OrderRepository(string connection)
        {
            constr = connection;
        }

        //------------------------------------------20190104 檢查庫存
        public async Task<int> MemberCartCheck(int ProductId, int SizeId, int ColorId, int Quantity)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@SizeId", SizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ColorId", ColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Quantity", Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_MemberCartCheck", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<OrderCheckProductStockEnoughViewModel>> OrderCheckProductStockEnough(string OrderId)
        {
            List<OrderCheckProductStockEnoughViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<OrderCheckProductStockEnoughViewModel> tmp = await con.QueryAsync<OrderCheckProductStockEnoughViewModel>("sp_OrderCheckProductStockEnough", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<OrderCheckProductStockEnoughViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        //------------------------------------------20190104 檢查庫存

        //------------------------------------------20190103 Sync銷貨管理
        public ShipmentIdViewModel SyncGetNewShipmentId(DateTime ShipTime)
        {
            ShipmentIdViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ShipTime", ShipTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    con.OpenAsync();
                    IEnumerable<ShipmentIdViewModel> tmp = con.Query<ShipmentIdViewModel>("sp_GetNewShipmentId", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<ShipmentIdViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public int SyncInsertShipMent(string ShipmentId, string MemberName, string ContactAddress, string MemberMobile, string Nnuber, string Weight,
    string Quantity, string Station, string MemberId, string ProductNo, string Product, string Phone, string Postal, string PaymentType, string InsteadReceive,
    string Memo, DateTime ShipTime, string OrderId)
        {
            int ret = 0;
            DynamicParameters p;
            DateTime dt = DateTime.Now;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.OpenAsync();
                    p = new DynamicParameters();
                    p.Add("@ShipmentId", ShipmentId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ContactAddress", ContactAddress, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Nnuber", Nnuber, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Weight", Weight, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Quantity", Quantity, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Station", Station, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberId", MemberId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductNo", ProductNo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Phone", Phone, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Postal", Postal, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PaymentType", PaymentType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@InsteadReceive", InsteadReceive, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Memo", Memo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ShipTime", ShipTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    con.Execute("sp_InsertShipMent", p, commandType: CommandType.StoredProcedure);
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

        public OrderListViewModel SyncGetOrderData(string OrderId)
        {
            OrderListViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    con.OpenAsync();
                    IEnumerable<OrderListViewModel> tmp = con.Query<OrderListViewModel>("sp_GetOrderData", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<OrderListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public List<CartListViewModel> SyncGetOrderDetail(string OrderId)
        {
            List<CartListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    con.OpenAsync();
                    IEnumerable<CartListViewModel> tmp = con.Query<CartListViewModel>("sp_GetOrderDetail", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<CartListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        //------------------------------------------20190103 非同步 銷貨管理

        //20181130 ---棋
        //5.系統在POST Action【MemberBonus/AccountMemberBonus】入帳月營運獎金。
        public async Task<int> AccountMemberBonus(int Month)
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
                    await con.ExecuteAsync("sp_AccountMemberBonus", p, commandType: CommandType.StoredProcedure);
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

        //20181130 ---棋
        //5.系統在POST Action【MemberBonus/CaculateMemberBonus】計算月營運獎金。
        public async Task<int> CaculateMemberBonus(int Month)
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
                    await con.ExecuteAsync("sp_CaculateMemberBonus", p, commandType: CommandType.StoredProcedure);
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

        public async Task<OrderIdViewModel> GetNewOrderId(DateTime OrderTime)
        {
            OrderIdViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderTime", OrderTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<OrderIdViewModel> tmp = await con.QueryAsync<OrderIdViewModel>("sp_GetNewOrderId", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<OrderIdViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertOrder(string OrderId, DateTime OrderTime, string MemberMobile, decimal Freight,
            decimal ProductFee, decimal TotalExpense, string MemberName, string eMail, string Phone,
            string ContactAddress, string CheckMacValue, List<CartListViewModel> Carts, string TradeNo, string Mobile)
        {
            string sql1 = @"INSERT INTO [dbo].[t_OrderDetail] (OrderId, ProductId, ProducSizeId, ProductColorId, Price, Quantity) VALUES (@OrderId, @ProductId, @ProducSizeId, @ProductColorId, @Price, @Quantity)";
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
                        p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add("@OrderTime", OrderTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                        p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add("@Freight", Freight, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                        p.Add("@ProductFee", ProductFee, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                        p.Add("@TotalExpense", TotalExpense, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                        p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add("@eMail", eMail, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add("@Phone", Phone, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add("@ContactAddress", ContactAddress, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add("@CheckMacValue", CheckMacValue, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add("@TradeNo", TradeNo, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add("@Mobile", Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                        await con.ExecuteAsync("sp_InsertOrder", p, commandType: CommandType.StoredProcedure, transaction: trans);
                        await con.ExecuteAsync(sql1, Carts, commandType: CommandType.Text, transaction: trans);
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

        public async Task<CheckMacValueModel> GetOrderCheckMacValue(string TradeNo)
        {
            CheckMacValueModel ret = null;
            int r = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@TradeNo", TradeNo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<CheckMacValueModel> tmp = await con.QueryAsync<CheckMacValueModel>("sp_GetOrderCheckMacValue", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<CheckMacValueModel>();
                    r = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
                r = 1;
            }
            if (r != 0)
                // 執行失敗
                ret = null;
            else
            {
                if (ret == null)
                {
                    // 找不到CheckMacValue
                    ret = new CheckMacValueModel { CheckMacValue = "" };
                }
            }
            return ret;
        }

        public async Task<int> UpdateOrderGreenCard(string OrderId, byte OrderStateId, string TradeDate,
                                                    string PaymentType, int TradeAmt, string GreenTradeNo, DateTime PaymentTime)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@OrderStateId", OrderStateId, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    p.Add("@TradeDate", TradeDate, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PaymentType", PaymentType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@TradeAmt", TradeAmt, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@GreenTradeNo", GreenTradeNo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PaymentTime", PaymentTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateOrderGreenCard", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> UpdateOrderGreenATMCVS(string OrderId, byte OrderStateId, string TradeDate, string PaymentType, int TradeAmt, string GreenTradeNo,
                    string BankCode, string vAccount, string ExpireDate, string PaymentNo)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@OrderStateId", OrderStateId, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    p.Add("@TradeDate", TradeDate, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PaymentType", PaymentType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@TradeAmt", TradeAmt, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@GreenTradeNo", GreenTradeNo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@BankCode", BankCode, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@vAccount", vAccount, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ExpireDate", ExpireDate, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PaymentNo", PaymentNo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateOrderGreenATMCVS", p, commandType: CommandType.StoredProcedure);
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

        public async Task<long> GetMemberOrderListCount(string MemberMobile, DateTime? sDate, DateTime? eDate, string Product = "", string OrderId = "", byte OrderStateId = 0)
        {
            if (MemberMobile == null) MemberMobile = "";
            if (Product == null) Product = "";
            if (OrderId == null) OrderId = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@OrderStateId", OrderStateId, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMemberOrderListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<OrderListViewModel>> GetMemberOrderList(string MemberMobile, DateTime? sDate, DateTime? eDate, string Product, string OrderId, byte OrderStateId, int Skip, int RowsPerPage)
        {
            if (MemberMobile == null) MemberMobile = "";
            if (Product == null) Product = "";
            if (OrderId == null) OrderId = "";
            List<OrderListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@OrderStateId", OrderStateId, dbType: DbType.Byte, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<OrderListViewModel> tmp = await con.QueryAsync<OrderListViewModel>("sp_GetMemberOrderList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<OrderListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<List<CartListViewModel>> GetOrderDetail(string OrderId)
        {
            List<CartListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    await con.OpenAsync();
                    IEnumerable<CartListViewModel> tmp = await con.QueryAsync<CartListViewModel>("sp_GetOrderDetail", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<CartListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<List<OrderStateViewModel>> GetOrderState()
        {
            List<OrderStateViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<OrderStateViewModel> tmp = await con.QueryAsync<OrderStateViewModel>("sp_GetOrderState", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<OrderStateViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<long> GetOrderDetailListCount(string OrderId)
        {
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetOrderDetailListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<CartListViewModel>> GetOrderDetailList(string OrderId, int Skip, int RowsPerPage)
        {
            List<CartListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<CartListViewModel> tmp = await con.QueryAsync<CartListViewModel>("sp_GetOrderDetailList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<CartListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<OrderListViewModel> GetOrderData(string OrderId)
        {
            OrderListViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<OrderListViewModel> tmp = await con.QueryAsync<OrderListViewModel>("sp_GetOrderData", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<OrderListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<ShipmentIdViewModel> GetNewShipmentId(DateTime ShipTime)
        {
            ShipmentIdViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ShipTime", ShipTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ShipmentIdViewModel> tmp = await con.QueryAsync<ShipmentIdViewModel>("sp_GetNewShipmentId", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<ShipmentIdViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateProductStock(List<CartListViewModel> listUMRM)
        {
            string sql1 = @"Update [dbo].t_ProductStock Set Stock=Stock-@Quantity Where ProductId=@ProductId and ProducSizeId=@ProducSizeId and ProductColorId=@ProductColorId";
            int ret = 0;
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
                ret = -1;
            }
            return ret;
        }

        public async Task<int> InsertShipMent(string ShipmentId, string MemberName, string ContactAddress, string MemberMobile, string Nnuber, string Weight,
            string Quantity, string Station, string MemberId, string ProductNo, string Product, string Phone, string Postal, string PaymentType, string InsteadReceive,
            string Memo, DateTime ShipTime, string OrderId)
        {
            int ret = 0;
            DynamicParameters p;
            DateTime dt = DateTime.Now;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    await con.OpenAsync();
                    p = new DynamicParameters();
                    p.Add("@ShipmentId", ShipmentId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberName", MemberName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ContactAddress", ContactAddress, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Nnuber", Nnuber, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Weight", Weight, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Quantity", Quantity, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Station", Station, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MemberId", MemberId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductNo", ProductNo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Phone", Phone, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Postal", Postal, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PaymentType", PaymentType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@InsteadReceive", InsteadReceive, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Memo", Memo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ShipTime", ShipTime, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@OrderId", OrderId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.ExecuteAsync("sp_InsertShipMent", p, commandType: CommandType.StoredProcedure);
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

        public async Task<long> GetFollowertriumphCount(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile)
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
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetFollowertriumphCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<FollowertriumphViewModel>> GetFollowertriumphList(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile, int Skip, int RowsPerPage)
        {
            if (MemberMobile == null) MemberMobile = "";
            if (ReferrerMobile == null) ReferrerMobile = "";
            List<FollowertriumphViewModel> ret = null;
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
                    IEnumerable<FollowertriumphViewModel> tmp = await con.QueryAsync<FollowertriumphViewModel>("sp_GetFollowertriumphList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<FollowertriumphViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<FollowertriumphTotalViewModel> GetFollowertriumphTotal(DateTime? sDate, DateTime? eDate, string ReferrerMobile)
        {
            if (ReferrerMobile == null) ReferrerMobile = "";
            FollowertriumphTotalViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<FollowertriumphTotalViewModel> tmp = await con.QueryAsync<FollowertriumphTotalViewModel>("sp_GetFollowertriumphTotal", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<FollowertriumphTotalViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<FollowertriumphTotalViewModel> GetMemberTotal(DateTime? sDate, DateTime? eDate, string MemberMobile)
        {
            if (MemberMobile == null) MemberMobile = "";
            FollowertriumphTotalViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<FollowertriumphTotalViewModel> tmp = await con.QueryAsync<FollowertriumphTotalViewModel>("sp_GetMemberTotal", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<FollowertriumphTotalViewModel>();
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