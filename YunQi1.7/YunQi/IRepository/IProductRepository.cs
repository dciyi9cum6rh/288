using DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IProductRepository
    {
        string constr { get; set; }

        //SqlConnection con { get; set; }
        Task<List<ProductLevelPathViewModel>> GetProductLevelPath(int ProductCategoryId);

        Task<long> GetProductCategoryCount(int ProductCategoryId, string ProductCategory);

        Task<List<ProductCategoryViewModel>> GetProductCategory(int ProductCategoryId, string ProductCategory, int Skip, int RowsPerPage);

        Task<OneProductCategoryViewModel> GetOneProductCategory(int ProductCategoryId);

        Task<int> InsertProductCategory(string ProductCategory, string ProductCategoryDescription, byte[] PictureContent, string PictureType, int ParentProductCategoryId);

        Task<int> UpdateProductCategory(string ProductCategory, string ProductCategoryDescription, byte[] PictureContent, string PictureType, int ProductCategoryId);

        Task<int> DeleteProductCategory(int ProductCategoryId);

        Task<long> GetProductListCount(string ProductCategory, string Product);

        Task<List<ProductListViewModel>> GetProductList(string ProductCategory, string Product, int Skip, int RowsPerPage);

        Task<int> InsertProduct(int ProductCategoryId, string Product, string ProductDescription, int Price, int OfferPrice, int SaleLimitPrice);

        Task<int> GetProductLastId();

        Task<int> InsertProductSize(int ProductId, string Size);

        Task<int> InsertProductColor(int ProductId, string Color);

        Task<ProductListViewModel> GetProduct(int ProductId);

        Task<ProductImageViewModel> GetProductImage(int ProductId);

        Task<ProductImageViewModel> GetOneProductImage(int ProductId, int ProductImageId);

        Task<List<ProductSizeViewModel>> GetProductSize(int ProductId);

        List<ProductSizeViewModel> GetProductSizeSync(int ProductId);

        Task<List<ProductColorViewModel>> GetProductColor(int ProductId);

        List<ProductColorViewModel> GetProductColorSync(int ProductId);

        Task<int> UpdateProduct(int ProductId, string Product, string ProductDescription, int Price, int OfferPrice, int SaleLimitPrice);

        Task<int> DeleteProduct(int ProductId);

        Task<long> GetProductImageListCount(int ProductId);

        Task<List<ProductImageListViewModel>> GetProductImageList(int ProductId, int Skip, int RowsPerPage);

        Task<int> InsertProductImage(int ProductId, string FileName, byte[] PictureContent, string PictureType);

        Task<int> UpdateProductImage(int ProductId, int ProductImageId, string FileName, byte[] PictureContent, string PictureType);

        Task<int> DeleteProductImage(int ProductId, int ProductImageId);

        Task<int> SetProductImage(int ProductId, int ProductImageId);

        Task<int> UpdateProductStock(int ProductId, int ProducSizeId, int ProductColorId, int Stock, int StockConsolidatio, int Consolidation, string UpdateEmployeeMobile);

        Task<int> DeleteProductSize(int ProductId, string ProductSize);

        Task<int> DeleteProductColor(int ProductId, string ProductColor);

        Task<long> GetProductStockListCount(int ProductId);

        Task<List<ProductStockListViewModel>> GetProductStockList(int ProductId, int Skip, int RowsPerPage);

        Task<long> GetStockCount(DateTime? sDate, DateTime? eDate, string Product);

        Task<List<StockListViewModel>> GetStockList(DateTime? sDate, DateTime? eDate, string Product, int Skip, int RowsPerPage);

        Task<ValidateProductViewModel> ValidateProduct(int ProductId, string Product);

        Task<List<ProductListViewModel>> GetNewProductList(int n);

        Task<ProductCategoryViewModel> GetTopProductCategory();

        Task<long> GetProductListCountMall(int ProductCategoryId, string Product, int lowPrice, int hightPrice);

        Task<List<ProductListViewModel>> GetProductListMall(int ProductCategoryId, string Product, int lowPrice, int hightPrice, int Skip, int RowsPerPage);

        Task<ProductCategoryViewModel> GetProductCategoryId(string ProductCategory);

        Task<ProductStockListViewModel> GetProductStock(int ProductId, int ProducSizeId, int ProductColorId);

        Task<List<ProductListViewModel>> GetOfferProductList();

        Task<int> InsertOfferProduct(int ProductId, string Product);

        Task<int> DeleteOfferProduct(int ProductId);

        Task<long> GetOfferProductListCountMall();

        Task<List<ProductListViewModel>> GetOfferProductListMall();

        Task<int> InsertProductImageMulti(List<UploadFile> lstUF);

        Task<int> UpdateProductImageOrder(List<ProductImageListViewModel> lstPILVM);

        //20181130 ---棋
        Task<List<MemberBonusListViewModel>> GetMemberBonusList(int Month, string ReferrerMobile, int Skip, int RowsPerPage);

        //20181204 ---棋
        Task<List<MemberDevelopmentBonusListViewModel>> GetMemberDevelopmentBonusList(int Month, string MemberMobile, int Skip = 0, int RowsPerPage = 10);

        //20181205 ---棋
        Task<List<EmployeeDevelopmentBonusListViewModel>> EmployeeDevelopmentBonusList(int Month, string MemberMobile, int Skip = 0, int RowsPerPage = 10);
    }
}