using DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IPurchaseRepository
    {
        string constr { get; set; }

        Task<long> GetPurchaseListCount(DateTime? sDate, DateTime? eDate, string Product = "", string PurchaseId = "");

        Task<List<PurchaseListViewModel>> GetPurchaseList(DateTime? sDate, DateTime? eDate, int Skip, int RowsPerPage, string Product = "", string PurchaseId = "");

        Task<long> GetPurchaseDetailListCount(string PurchaseId);

        Task<List<PurchaseDetailListViewModel>> GetPurchaseDetailList(string PurchaseId, int Skip, int RowsPerPage);

        Task<List<CurrencyViewModel>> GetCurrency();

        Task<PurchaseIdViewModel> GetNewPurchaseId(DateTime PurchaseTime);

        Task<int> InsertPurchase(string PurchaseId, DateTime PurchaseTime, string UpdateEmployeeMobile, int CurrencyId, decimal ExchangeRate, decimal Freight, decimal miscellaneous, decimal ProductFee);

        Task<int> InsertPurchaseDetail(string PurchaseId, int ProductId, int ProducSizeId, int ProductColorId, decimal PurchasePrice, int Quantity, decimal ExchangeRate);

        Task<PurchaseListViewModel> GetPurchase(string PurchaseId);

        Task<int> UpdatePurchase(string PurchaseId, DateTime PurchaseTime, string UpdateEmployeeMobile, int CurrencyId, decimal ExchangeRate, decimal Freight, decimal miscellaneous, decimal ProductFee);

        Task<int> DeletePurchase(string PurchaseId);

        Task<int> DeletePurchaseDetail(string PurchaseId, int PurchaseDetailId);
    }
}