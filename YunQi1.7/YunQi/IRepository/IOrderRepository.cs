using DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IOrderRepository
    {
        string constr { get; set; }

        Task<OrderIdViewModel> GetNewOrderId(DateTime OrderTime);

        Task<int> InsertOrder(string OrderId, DateTime OrderTime, string MemberMobile, decimal Freight,
            decimal ProductFee, decimal TotalExpense, string MemberName, string eMail, string Phone,
            string ContactAddress, string CheckMacValue, List<CartListViewModel> Carts, string TradeNo, string Mobile);

        Task<CheckMacValueModel> GetOrderCheckMacValue(string TradeNo);

        Task<int> UpdateOrderGreenCard(string OrderId, byte OrderStateId, string TradeDate, string PaymentType, int TradeAmt, string GreenTradeNo, DateTime PaymentTime);

        Task<int> UpdateOrderGreenATMCVS(string OrderId, byte OrderStateId, string TradeDate, string PaymentType, int TradeAmt, string GreenTradeNo, string BankCode, string vAccount, string ExpireDate, string PaymentNo);

        Task<long> GetMemberOrderListCount(string MemberMobile, DateTime? sDate, DateTime? eDate, string Product = "", string OrderId = "", byte OrderStateId = 0);

        Task<List<OrderListViewModel>> GetMemberOrderList(string MemberMobile, DateTime? sDate, DateTime? eDate, string Product, string OrderId, byte OrderStateId, int Skip, int RowsPerPage);

        Task<List<CartListViewModel>> GetOrderDetail(string OrderId);

        Task<List<OrderStateViewModel>> GetOrderState();

        Task<long> GetOrderDetailListCount(string OrderId);

        Task<List<CartListViewModel>> GetOrderDetailList(string OrderId, int Skip, int RowsPerPage);

        Task<OrderListViewModel> GetOrderData(string OrderId);

        Task<ShipmentIdViewModel> GetNewShipmentId(DateTime ShipTime);

        Task<int> UpdateProductStock(List<CartListViewModel> listUMRM);

        Task<int> InsertShipMent(string ShipmentId, string MemberName, string ContactAddress, string MemberMobile, string Nnuber, string Weight,
            string Quantity, string Station, string MemberId, string ProductNo, string Product, string Phone, string Postal, string PaymentType, string InsteadReceive,
            string Memo, DateTime ShipTime, string OrderId);

        Task<long> GetFollowertriumphCount(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile);

        Task<List<FollowertriumphViewModel>> GetFollowertriumphList(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile, int Skip, int RowsPerPage);

        Task<FollowertriumphTotalViewModel> GetFollowertriumphTotal(DateTime? sDate, DateTime? eDate, string ReferrerMobile);

        Task<FollowertriumphTotalViewModel> GetMemberTotal(DateTime? sDate, DateTime? eDate, string MemberMobile);

        Task<int> CaculateMemberBonus(int Month);   //20181130 ---棋

        Task<int> AccountMemberBonus(int Month);    //20181130 ---棋

        //20190103 ---棋
        ShipmentIdViewModel SyncGetNewShipmentId(DateTime ShipTime);

        int SyncInsertShipMent(string ShipmentId, string MemberName, string ContactAddress, string MemberMobile, string Nnuber, string Weight, string Quantity, string Station, string MemberId, string ProductNo, string Product, string Phone, string Postal, string PaymentType, string InsteadReceive, string Memo, DateTime ShipTime, string OrderId);

        OrderListViewModel SyncGetOrderData(string OrderId);

        List<CartListViewModel> SyncGetOrderDetail(string OrderId);

        //20190104 ---棋
        Task<int> MemberCartCheck(int ProductId, int SizeId, int ColorId, int Quantity);

        Task<List<OrderCheckProductStockEnoughViewModel>> OrderCheckProductStockEnough(string OrderId);
    }
}