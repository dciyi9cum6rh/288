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
    public class ProductRepository : IProductRepository
    {
        public string constr { get; set; }
        //public SqlConnection con { get; set; }

        public ProductRepository()
        {
            constr = "";
            //con = new SqlConnection(constr);
        }

        public ProductRepository(string connection)
        {
            constr = connection;
            //con = new SqlConnection(constr);
        }

        //------------------------------------------YunQiERP 業務獎金管理
        //20181205  ---棋
        //9-5.系統在ViewComponent【EmployeeDevelopmentBonusList】讀取批發會員獎金記錄清單：
        public async Task<List<EmployeeDevelopmentBonusListViewModel>> EmployeeDevelopmentBonusList(int Month, string EmployeeMobile, int Skip = 0, int RowsPerPage = 10)
        {
            List<EmployeeDevelopmentBonusListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@EmployeeMobile", EmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<EmployeeDevelopmentBonusListViewModel> tmp = await con.QueryAsync<EmployeeDevelopmentBonusListViewModel>("sp_GetEmployeeDevelopmentBonusList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<EmployeeDevelopmentBonusListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        //------------------------------------------YunQiERP 業務獎金管理

        //------------------------------------------YunQiERP 直屬會員發展獎金管理
        //20181203  ---棋
        //9-5.系統在ViewComponent【GetMemberDevelopmentBonusList】讀取批發會員獎金記錄清單：
        public async Task<List<MemberDevelopmentBonusListViewModel>> GetMemberDevelopmentBonusList(int Month, string MemberMobile, int Skip = 0, int RowsPerPage = 10)
        {
            List<MemberDevelopmentBonusListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@MemberMobile", MemberMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberDevelopmentBonusListViewModel> tmp = await con.QueryAsync<MemberDevelopmentBonusListViewModel>("sp_GetMemberDevelopmentBonusList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberDevelopmentBonusListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        //------------------------------------------YunQiERP 直屬會員發展獎金管理

        //------------------------------------------YunQiERP 批發會員獎金設定
        //20181130  ---棋
        //9-5.系統在ViewComponent【MemberBonusListViewComponent】讀取批發會員獎金記錄清單：
        public async Task<List<MemberBonusListViewModel>> GetMemberBonusList(int Month, string ReferrerMobile, int Skip = 0, int RowsPerPage = 10)
        {
            List<MemberBonusListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Month", Month, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ReferrerMobile", ReferrerMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MemberBonusListViewModel> tmp = await con.QueryAsync<MemberBonusListViewModel>("sp_GetMemberBonusList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MemberBonusListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        //------------------------------------------YunQiERP 批發會員獎金設定

        public async Task<List<ProductLevelPathViewModel>> GetProductLevelPath(int ProductCategoryId)
        {
            List<ProductLevelPathViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategoryId", ProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductLevelPathViewModel> tmp = await con.QueryAsync<ProductLevelPathViewModel>("sp_GetProductLevelPath", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductLevelPathViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<long> GetProductCategoryCount(int ProductCategoryId, string ProductCategory)
        {
            if (ProductCategory == null) ProductCategory = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategoryId", ProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductCategory", ProductCategory, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    //var tmp = await con.QueryMultipleAsync("sp_GetMemberCount", p, commandType: CommandType.StoredProcedure);
                    //ret = tmp.Read<long>().FirstOrDefault();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetProductCategoryCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<ProductCategoryViewModel>> GetProductCategory(int ProductCategoryId, string ProductCategory, int Skip, int RowsPerPage)
        {
            if (ProductCategory == null) ProductCategory = "";
            List<ProductCategoryViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategoryId", ProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductCategory", ProductCategory, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductCategoryViewModel> tmp = await con.QueryAsync<ProductCategoryViewModel>("sp_GetProductCategory", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductCategoryViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<OneProductCategoryViewModel> GetOneProductCategory(int ProductCategoryId)
        {
            OneProductCategoryViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategoryId", ProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<OneProductCategoryViewModel> tmp = await con.QueryAsync<OneProductCategoryViewModel>("sp_GetOneProductCategory", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<OneProductCategoryViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertProductCategory(string ProductCategory, string ProductCategoryDescription, byte[] PictureContent, string PictureType, int ParentProductCategoryId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategory", ProductCategory, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductCategoryDescription", ProductCategoryDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@PictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ParentProductCategoryId", ParentProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertProductCategory", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> UpdateProductCategory(string ProductCategory, string ProductCategoryDescription, byte[] PictureContent, string PictureType, int ProductCategoryId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategory", ProductCategory, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductCategoryDescription", ProductCategoryDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@PictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductCategoryId", ProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateProductCategory", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteProductCategory(int ProductCategoryId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategoryId", ProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteProductCategory", p, commandType: CommandType.StoredProcedure);
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

        public async Task<long> GetProductListCount(string ProductCategory, string Product)
        {
            if (ProductCategory == null) ProductCategory = "";
            if (Product == null) Product = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategory", ProductCategory, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetProductListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<ProductListViewModel>> GetProductList(string ProductCategory, string Product, int Skip, int RowsPerPage)
        {
            if (ProductCategory == null) ProductCategory = "";
            if (Product == null) Product = "";
            List<ProductListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategory", ProductCategory, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductListViewModel> tmp = await con.QueryAsync<ProductListViewModel>("sp_GetProductList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertProduct(int ProductCategoryId, string Product, string ProductDescription, int Price, int OfferPrice, int SaleLimitPrice)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategoryId", ProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductDescription", ProductDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Price", Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@OfferPrice", OfferPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@SaleLimitPrice", SaleLimitPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertProduct", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> GetProductLastId()
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_GetProductLastId", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> InsertProductSize(int ProductId, string Size)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Size", Size, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertProductSize", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> InsertProductColor(int ProductId, string Color)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Color", Color, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertProductColor", p, commandType: CommandType.StoredProcedure);
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

        public async Task<ProductListViewModel> GetProduct(int ProductId)
        {
            ProductListViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductListViewModel> tmp = await con.QueryAsync<ProductListViewModel>("sp_GetProduct", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<ProductListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<ProductImageViewModel> GetProductImage(int ProductId)
        {
            ProductImageViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductImageViewModel> tmp = await con.QueryAsync<ProductImageViewModel>("sp_GetProductImage", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<ProductImageViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<ProductImageViewModel> GetOneProductImage(int ProductId, int ProductImageId)
        {
            ProductImageViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductImageId", ProductImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductImageViewModel> tmp = await con.QueryAsync<ProductImageViewModel>("sp_GetOneProductImage", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<ProductImageViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<List<ProductSizeViewModel>> GetProductSize(int ProductId)
        {
            List<ProductSizeViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductSizeViewModel> tmp = await con.QueryAsync<ProductSizeViewModel>("sp_GetProductSize", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductSizeViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public List<ProductSizeViewModel> GetProductSizeSync(int ProductId)
        {
            List<ProductSizeViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    con.Open();
                    IEnumerable<ProductSizeViewModel> tmp = con.Query<ProductSizeViewModel>("sp_GetProductSize", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductSizeViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<List<ProductColorViewModel>> GetProductColor(int ProductId)
        {
            List<ProductColorViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductColorViewModel> tmp = await con.QueryAsync<ProductColorViewModel>("sp_GetProductColor", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductColorViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public List<ProductColorViewModel> GetProductColorSync(int ProductId)
        {
            List<ProductColorViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    con.Open();
                    IEnumerable<ProductColorViewModel> tmp = con.Query<ProductColorViewModel>("sp_GetProductColor", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductColorViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateProduct(int ProductId, string Product, string ProductDescription, int Price, int OfferPrice, int SaleLimitPrice)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductDescription", ProductDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Price", Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@OfferPrice", OfferPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@SaleLimitPrice", SaleLimitPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateProduct", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteProduct(int ProductId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteProduct", p, commandType: CommandType.StoredProcedure);
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

        public async Task<long> GetProductImageListCount(int ProductId)
        {
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetProductImageListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<ProductImageListViewModel>> GetProductImageList(int ProductId, int Skip, int RowsPerPage)
        {
            List<ProductImageListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductImageListViewModel> tmp = await con.QueryAsync<ProductImageListViewModel>("sp_GetProductImageList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductImageListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertProductImage(int ProductId, string FileName, byte[] PictureContent, string PictureType)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@FileName", FileName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@PictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertProductImage", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> UpdateProductImage(int ProductId, int ProductImageId, string FileName, byte[] PictureContent, string PictureType)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductImageId", ProductImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@FileName", FileName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@PictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateProductImage", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteProductImage(int ProductId, int ProductImageId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductImageId", ProductImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteProductImage", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> SetProductImage(int ProductId, int ProductImageId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductImageId", ProductImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_SetProductImage", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> UpdateProductStock(int ProductId, int ProducSizeId, int ProductColorId, int Stock, int StockConsolidatio, int Consolidation, string UpdateEmployeeMobile)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProducSizeId", ProducSizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductColorId", ProductColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Stock", Stock, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@StockConsolidatio", StockConsolidatio, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Consolidation", Consolidation, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@UpdateEmployeeMobile", UpdateEmployeeMobile, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateProductStock", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteProductSize(int ProductId, string ProductSize)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductSize", ProductSize, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteProductSize", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteProductColor(int ProductId, string ProductColor)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductColor", ProductColor, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteProductColor", p, commandType: CommandType.StoredProcedure);
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

        public async Task<long> GetProductStockListCount(int ProductId)
        {
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetProductStockListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<ProductStockListViewModel>> GetProductStockList(int ProductId, int Skip, int RowsPerPage)
        {
            List<ProductStockListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductStockListViewModel> tmp = await con.QueryAsync<ProductStockListViewModel>("sp_GetProductStockList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductStockListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<long> GetStockCount(DateTime? sDate, DateTime? eDate, string Product)
        {
            if (Product == null) Product = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetStockCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = -1;
            }
            return ret;
        }

        public async Task<List<StockListViewModel>> GetStockList(DateTime? sDate, DateTime? eDate, string Product, int Skip, int RowsPerPage)
        {
            if (Product == null) Product = "";
            List<StockListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@sDate", sDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@eDate", eDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<StockListViewModel> tmp = await con.QueryAsync<StockListViewModel>("sp_GetStockList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<StockListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<ValidateProductViewModel> ValidateProduct(int ProductId, string Product)
        {
            ValidateProductViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ValidateProductViewModel> tmp = await con.QueryAsync<ValidateProductViewModel>("sp_ValidateProduct", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<ValidateProductViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<List<ProductListViewModel>> GetNewProductList(int n)
        {
            List<ProductListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@n", n, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductListViewModel> tmp = await con.QueryAsync<ProductListViewModel>("sp_GetNewProductList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<ProductCategoryViewModel> GetTopProductCategory()
        {
            ProductCategoryViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductCategoryViewModel> tmp = await con.QueryAsync<ProductCategoryViewModel>("sp_GetTopProductCategory", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<ProductCategoryViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<long> GetProductListCountMall(int ProductCategoryId, string Product, int lowPrice, int hightPrice)
        {
            if (Product == null) Product = "";
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategoryId", ProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@lowPrice", lowPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@hightPrice", hightPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetProductListCountMall", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<ProductListViewModel>> GetProductListMall(int ProductCategoryId, string Product, int lowPrice, int hightPrice, int Skip, int RowsPerPage)
        {
            if (Product == null) Product = "";
            List<ProductListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategoryId", ProductCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@lowPrice", lowPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@hightPrice", hightPrice, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductListViewModel> tmp = await con.QueryAsync<ProductListViewModel>("sp_GetProductListMall", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<ProductCategoryViewModel> GetProductCategoryId(string ProductCategory)
        {
            ProductCategoryViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductCategory", ProductCategory, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductCategoryViewModel> tmp = await con.QueryAsync<ProductCategoryViewModel>("sp_GetProductCategoryId", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<ProductCategoryViewModel>();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<ProductStockListViewModel> GetProductStock(int ProductId, int ProducSizeId, int ProductColorId)
        {
            ProductStockListViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProducSizeId", ProducSizeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@ProductColorId", ProductColorId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductStockListViewModel> tmp = await con.QueryAsync<ProductStockListViewModel>("sp_GetProductStock", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<ProductStockListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<List<ProductListViewModel>> GetOfferProductList()
        {
            List<ProductListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductListViewModel> tmp = await con.QueryAsync<ProductListViewModel>("sp_GetOfferProductList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertOfferProduct(int ProductId, string Product)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@Product", Product, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertOfferProduct", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteOfferProduct(int ProductId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", ProductId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteOfferProduct", p, commandType: CommandType.StoredProcedure);
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

        public async Task<long> GetOfferProductListCountMall()
        {
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetOfferProductListCountMall", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<ProductListViewModel>> GetOfferProductListMall()
        {
            List<ProductListViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ProductListViewModel> tmp = await con.QueryAsync<ProductListViewModel>("sp_GetOfferProductListMall", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ProductListViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertProductImageMulti(List<UploadFile> lstUF)
        {
            int ret = 0;
            ProductListViewModel plvm = new ProductListViewModel();
            plvm.ProductId = lstUF[0].ProductId;
            string sql1 = @"DELETE FROM t_ProductImage WHERE ProductId=@ProductId";
            string sql2 = @"INSERT INTO [dbo].[t_ProductImage] (ProductId, [FileName], PictureContent, PictureType,DisplayOrder) VALUES(@ProductId, @FileName, @PictureContent, @PictureType,@DisplayOrder)";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    await con.OpenAsync();
                    using (var trans = con.BeginTransaction())
                    {
                        await con.ExecuteAsync(sql1, plvm, commandType: CommandType.Text, transaction: trans);
                        await con.ExecuteAsync(sql2, lstUF, commandType: CommandType.Text, transaction: trans);
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
                ret = 3;
            }
            return ret;
        }

        public async Task<int> UpdateProductImageOrder(List<ProductImageListViewModel> lstPILVM)
        {
            int ret = 0;
            ProductListViewModel plvm = new ProductListViewModel();
            string sql1 = @"Update [dbo].[t_ProductImage] Set DisplayOrder=@DisplayOrder Where ProductId=@ProductId and ProductImageId=@ProductImageId";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    await con.OpenAsync();
                    using (var trans = con.BeginTransaction())
                    {
                        await con.ExecuteAsync(sql1, lstPILVM, commandType: CommandType.Text, transaction: trans);
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
                ret = 3;
            }
            return ret;
        }
    }
}