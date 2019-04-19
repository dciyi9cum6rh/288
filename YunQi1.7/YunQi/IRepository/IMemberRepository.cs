using DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IMemberRepository
    {
        string constr { get; set; }

        //Task<int> InsertMember(string MemberMobile, string Password, int MemberLevelId, string MemberName, string NickName, byte sex,
        //    DateTime Birthday, string eMail, string LineId, string Phone, string ContactAddress, string ID, string Bank, string Branch,
        //    string AccountNunber, string AccountName);
        Task<int> InsertMember(string MemberMobile, string Password, int MemberLevelId, string MemberName, string NickName, byte sex, string eMail, string ContactAddress, int ValidateCode);

        Task<int> MemberLogin(string MemberMobile, string Password);

        Task<MemberViewModel> GetMember(string MemberMobile);

        //Task<int> UpdateMember(string MemberMobile, string MemberName, string NickName, byte sex,
        //                                    DateTime Birthday, string eMail, string LineId, string Phone, string ContactAddress, string ID,
        //                                    string Bank, string Branch, string AccountNunber, string AccountName);
        Task<int> UpdateMember(string MemberMobile, string MemberName, string NickName, byte sex,
                                    DateTime? Birthday, string eMail, string LineId, string Phone, string ContactAddress);
        Task<long> GetMemberOrderBonusListCount(string memberMobile);
        Task<int> UpdateMemberLevel(string MemberMobile, int MemberLevelId, DateTime? VipApplyDate = null, DateTime? VipDate = null, string ReferrerMobile = "");
        Task<List<MemberOrderBonusListViewModel>> GetMemberOrderBonusList(string memberMobile, int skip, int rowsPerPage);
      
        Task<int> ChangeMemberBonusToMoney(int recordId);

        //Task<int> UpdateMemberLevelCart(string MemberMobile, int MemberLevelId, string ID, string Bank, string Branch, string AccountNunber, string AccountName, DateTime? VipApplyDate = null, DateTime? VipDate = null, string ReferrerMobile = "");
        //200181212 ---棋
        Task<int> UpdateMemberLevelCart(string FileName, byte[] PictureContent, string PictureType, string MemberMobile, int MemberLevelId, string ID, string Bank, string Branch, string AccountNunber, string AccountName, DateTime? VipApplyDate = null, DateTime? VipDate = null, string ReferrerMobile = "");

        Task<List<MemberLevelViewModel>> GetMembevLevel();

        Task<long> GetMemberListCount(string MemberMobile = "", string MemberName = "", string ReferrerMobile = "", int MemberLevelId = 0, int Enabled = 10);

        Task<List<MemberViewModel>> GetMemberList(string MemberMobile = "", string MemberName = "", string ReferrerMobile = "", int MemberLevelId = 0, int Enabled = 10, int Skip = 0, int RowsPerPage = 10);

        Task<int> UpdateMemberEnabled(string MemberMobile, byte Enabled);
        Task<long> GetMemberOrderBonusSum(string memberMobile);
        Task<int> UpdateMemberReferrer(List<UpdateMemberReferrerModel> listUMRM);

        Task<int> ValidateReferrerMobile(string ReferrerMobile);

        Task<int> InsertMemberFavorite(string MemberMobile, int ProductId);

        Task<long> GetMemberFavoriteListCount(string MemberMobile, string Product);

        Task<List<ProductListViewModel>> GetMemberFavoriteList(string MemberMobile, string Product, int Skip = 0, int RowsPerPage = 1000);

        Task<int> InsertMemberCarts(List<MemberCartsViewModel> carts);

        Task<List<CartListViewModel>> GetCartList(string MemberMobile);

        Task<int> DeleteMemberCart(string MemberMobile, int ProductId, int ProducSizeId, int ProductColorId);

        Task<int> DeleteMemberCarts(List<MemberCartsViewModel> carts);

        Task<int> UpdateMemberCart(string MemberMobile, int ProductId, int ProducSizeId, int ProductColorId, int ProducSizeIdN, int ProductColorIdN, string ProductSize, string ProductColor, int QuantityN);

        Task<int> UpdateOrderState(string OrderId, byte OrderStateId);

        Task<long> GetMyfollowerCount(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile);

        Task<List<MemberViewModel>> GetMyfollowerList(string MemberMobile, DateTime? sDate, DateTime? eDate, string ReferrerMobile, int Skip, int RowsPerPage);

        Task<int> DeleteAllMemberCarts(string MemberMobile);

        Task<int> DeleteMyfavorite(string MemberMobile, int ProductId);     //20181130 ---棋

        Task<long> GetMemberBonusListCount(int Month, string ReferrerMobile);        //20181129 ---棋

        Task<long> GetMemberBonusDetailListCount(string ReferrerMobile, int Month);            //20181129 ---棋

        Task<List<MemberBonusDetailListViewModel>> GetMemberBonusDetailList(string ReferrerMobile, int Month, int Skip, int RowsPerPage);     //20181129 ---棋

        //20181204 ---棋
        //YunQiERP 直屬會員發展獎金管理
        Task<int> AccountMemberDevelopmentBonus(int Month);

        Task<int> CaculateMemberDevelopmentBonus(int Month);

        Task<long> GetMemberDevelopmentBonusListCount(string MemberMobile, int Month);

        Task<long> GetMemberDevelopmentBonusDetailListCount(string ReferrerMobile, int Month);

        Task<List<MemberDevelopmentBonusDetailList>> GetMemberDevelopmentBonusDetailList(string ReferrerMobile, int Month, int Skip = 0, int RowsPerPage = 10);

        //20181205 ---棋
        //YunQiERP 業務發展獎金管理
        Task<int> AccountEmployeeDevelopmentBonus(int Month);

        Task<int> CaculateEmployeeDevelopmentBonus(int Month);
        Task<int> ChangeMemberBonus(string memberMobile, string memo, int bonus);
       
        Task<long> GetEmployeeDevelopmentBonusListCount(string MemberMobile, int Month);

        Task<long> GetEmployeeDevelopmentBonusDetailListCount(string ReferrerMobile, int Month);

        Task<List<EmployeeDevelopmentBonusDetailList>> GetEmployeeDevelopmentBonusDetailList(string ReferrerMobile, int Month, int Skip = 0, int RowsPerPage = 10);

        //20181207 ---棋
        //YunQiERP 忘記密碼
        Task<int> InsertMemberForget(string MemberMobile, long token);

        Task<int> MemberForget(string MemberMobile, long token);

        Task<int> UpdateMemberPassword(string MemberMobile, string Password, long token);

        //20181214 ---棋
        //YunQiERP 會員點數異動
        Task<long> GetBonusChangeRecordCount(string MemberMobile, DateTime? sDate, DateTime? eDate);

        Task<List<BonusChangeRecordListViewModel>> GetBonusChangeRecordList(string MemberMobile, DateTime? sDate, DateTime? eDate, int Skip = 0, int RowsPerPage = 10);

        Task<long> GetMemberBonusChangeRecordCount(string MemberMobile, DateTime? sDate, DateTime? eDate);

        Task<List<MemberBonusChangeRecordListViewModel>> GetMemberBonusChangeRecordList(string MemberMobile, int eventId, DateTime? sDate, DateTime? eDate, int Skip = 0, int RowsPerPage = 10);

        //20181216 ---棋
        //手機簡訊驗證
        Task<int> MemberVerification(string MemberMobile, int ValidateCode);

        //20181217 ---棋
        //訊息中心
        Task<long> GetMemberMailCenterMessageCount(string MemberMobile, string MessageValue);

        Task<List<MemberMailCenterMessageListViewModel>> GetMemberMailCenterMessageList(string MemberMobile, string MessageValue, int Skip = 0, int RowsPerPage = 10);

        Task<List<MemberLevelListViewModel>> GetMemberLevelList(int MemberLevelid);

        Task<List<MemberLevelViewModel>> GetMembevLevel(string MemberLevel);

        Task<int> InsertMemberMessage(List<memberMailCenter> memberMailCenter);

        Task<long> GetMailCenterUnReadCount(string MemberMobile);

        Task<long> UpdateMailCenterReadStates(string MemberMobile);

        //20181220 ---棋
        //送貨地址
        Task<long> GetMemberDeliveryAddressCount(string MemberMobile, string MemberName, string Phone, string DeliveryAddress);

        Task<List<MemberDeliveryAddressListViewModel>> GetMemberDeliveryAddressList(string MemberMobile, string MemberName, string Phone, string DeliveryAddress, int Skip = 0, int RowsPerPage = 10);

        Task<long> InsertMemberDeliveryAddress(string MemberMobile, string MemberName, string Phone, string DeliveryAddress, string eMail);

        Task<long> UpdateMemberDeliveryAddress(int MemberAddressId, string MemberMobile, string MemberNameN, string PhoneN, string DeliveryAddressN, string eMailN);

        Task<List<MemberDeliveryAddressListViewModel>> GetMemberDeliveryAddress(string MemberMobile, int MemberAddressId);

        //20181222 ---棋
        //YunQiWholesale 會員調撥區
        Task<long> GetMemberExchangeCount(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string NickName);

        Task<List<MemberExchangeListViewModel>> GetMemberExchangeList(int VersionId, DateTime? sDate, DateTime? eDate, string MessageValue, string NickName, int Skip = 0, int RowsPerPage = 10);

        Task<long> InsertMessageManagement(int VersionId, string MessageTitle, string MessageValue, string MemberMobile);

        //20181227 ---棋
        //YunQiWholesale 購物車清單
        Task<List<MemberCartOneListViewModel>> GetMemberCartOneList(string MemberMobile, int ProductId, int ProductSizeId, int ProductColorId);

        //20190103 ---棋
        //Sync銷貨管理
        int SyncUpdateOrderState(string OrderId, byte OrderStateId);
        Task<int> UsedMemberBonus(string v, int bonus, int usedBonus,int? EentId=5);
    }
}