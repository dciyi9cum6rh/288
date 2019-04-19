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
    public class MediaRepository : IMediaRepository
    {
        public string constr { get; set; }
        //public SqlConnection con { get; set; }

        public MediaRepository()
        {
            constr = "";
            //con = new SqlConnection(constr);
        }

        public MediaRepository(string connection)
        {
            constr = connection;
            //con = new SqlConnection(constr);
        }

        public async Task<long> GetHomeImageListCount()
        {
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMallImageListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<HomeImageViewModel>> GetHomeImageList(int Skip, int RowsPerPage)
        {
            List<HomeImageViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<HomeImageViewModel> tmp = await con.QueryAsync<HomeImageViewModel>("sp_GetHomeImageList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<HomeImageViewModel>();
                }
            }
            catch (Exception ex)
            {
                string meg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertHomeImage(string FileName, byte[] PictureContent, string PictureType, string HomeImageDescription)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@FileName", FileName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@PictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@HomeImageDescription", HomeImageDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertHomeImage", p, commandType: CommandType.StoredProcedure);
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

        public async Task<HomeImageViewModel> GetOneHomeImage(int HomeImageId)
        {
            HomeImageViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@HomeImageId", HomeImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<HomeImageViewModel> tmp = await con.QueryAsync<HomeImageViewModel>("sp_GetOneHomeImage", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<HomeImageViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateHomeImage(string FileName, byte[] PictureContent, string PictureType, string HomeImageDescription, int HomeImageId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@FileName", FileName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@PictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@HomeImageDescription", HomeImageDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@HomeImageId", HomeImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateHomeImage", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteHomeImage(int HomeImageId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@HomeImageId", HomeImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteHomeImage", p, commandType: CommandType.StoredProcedure);
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

        public async Task<long> GetMallImageListCount()
        {
            long ret = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<long> tmp = await con.QueryAsync<long>("sp_GetMallImageListCount", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                ret = -1;
            }
            return ret;
        }

        public async Task<List<MallImageViewModel>> GetMallImageList(int Skip, int RowsPerPage)
        {
            List<MallImageViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@Skip", Skip, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@RowsPerPage", RowsPerPage, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MallImageViewModel> tmp = await con.QueryAsync<MallImageViewModel>("sp_GetMallImageList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<MallImageViewModel>();
                }
            }
            catch (Exception ex)
            {
                string meg = ex.Message;
                ret = null;
            }
            return ret;
        }

        public async Task<int> InsertMallImage(string FileName, byte[] PictureContent, string PictureType, string MallImageDescription)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@FileName", FileName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@PictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MallImageDescription", MallImageDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_InsertMallImage", p, commandType: CommandType.StoredProcedure);
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

        public async Task<MallImageViewModel> GetOneMallImage(int MallImageId)
        {
            MallImageViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MallImageId", MallImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<MallImageViewModel> tmp = await con.QueryAsync<MallImageViewModel>("sp_GetOneMallImage", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<MallImageViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateMallImage(string FileName, byte[] PictureContent, string PictureType, string MallImageDescription, int MallImageId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@FileName", FileName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@PictureContent", PictureContent, dbType: DbType.Binary, direction: ParameterDirection.Input);
                    p.Add("@PictureType", PictureType, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MallImageDescription", MallImageDescription, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@MallImageId", MallImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateMallImage", p, commandType: CommandType.StoredProcedure);
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

        public async Task<int> DeleteMallImage(int MallImageId)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@MallImageId", MallImageId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_DeleteMallImage", p, commandType: CommandType.StoredProcedure);
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