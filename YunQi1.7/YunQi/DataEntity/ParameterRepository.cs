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
    public class ParameterRepository : IParameterRepository
    {
        public string constr { get; set; }
        //public SqlConnection con { get; set; }

        public ParameterRepository()
        {
            constr = "";
            //con = new SqlConnection(constr);
        }

        public ParameterRepository(string connection)
        {
            constr = connection;
            //con = new SqlConnection(constr);
        }

        public async Task<List<ParameterViewModel>> GetParameterList()
        {
            List<ParameterViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<ParameterViewModel> tmp = await con.QueryAsync<ParameterViewModel>("sp_GetParameterList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<ParameterViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateParameter(string ParameterId, string ParameterValue)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ParameterId", ParameterId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ParameterValue", ParameterValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateParameter", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 2;
            }
            return ret;
        }

        public async Task<List<DevelopmentBonusViewModel>> GetDevelopmentBonusList()
        {
            List<DevelopmentBonusViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<DevelopmentBonusViewModel> tmp = await con.QueryAsync<DevelopmentBonusViewModel>("sp_GetDevelopmentBonusList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<DevelopmentBonusViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateDevelopmentBonus(string DevelopmentBonusId, string DevelopmentBonusLimit, string DevelopmentBonusValue)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@DevelopmentBonusId", DevelopmentBonusId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@DevelopmentBonusLimit", DevelopmentBonusLimit, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@DevelopmentBonusValue", DevelopmentBonusValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateDevelopmentBonus", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 2;
            }
            return ret;
        }

        public async Task<List<FreightViewModel>> GetFreightList()
        {
            List<FreightViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<FreightViewModel> tmp = await con.QueryAsync<FreightViewModel>("sp_GetFreightList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<FreightViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateFreight(string FreightId, string FreightLimit, string FreightValue)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@FreightId", FreightId, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@FreightLimit", FreightLimit, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@FreightValue", FreightValue, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateFreight", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 2;
            }
            return ret;
        }

        public async Task<YoutubeVideoViewModel> GetYoutubeVideoList()
        {
            YoutubeVideoViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<YoutubeVideoViewModel> tmp = await con.QueryAsync<YoutubeVideoViewModel>("sp_GetYoutubeVideoList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<YoutubeVideoViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<int> UpdateYoutubeVideo(int YoutubeVideoId, string YoutubeVideo)
        {
            int ret = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@YoutubeVideoId", YoutubeVideoId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add("@@YoutubeVideo", YoutubeVideo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    await con.ExecuteAsync("sp_UpdateYoutubeVideo", p, commandType: CommandType.StoredProcedure);
                    ret = p.Get<int>("@r");
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = 2;
            }
            return ret;
        }

        public async Task<OrderFreightViewModel> GetOrderFreight(decimal ProductFee)
        {
            OrderFreightViewModel ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductFee", ProductFee, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<OrderFreightViewModel> tmp = await con.QueryAsync<OrderFreightViewModel>("sp_GetOrderFreight", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.FirstOrDefault<OrderFreightViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }

        public async Task<List<OutlyingIslandViewModel>> GetOutlyingIslandList()
        {
            List<OutlyingIslandViewModel> ret = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    var p = new DynamicParameters();
                    p.Add("@r", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                    await con.OpenAsync();
                    IEnumerable<OutlyingIslandViewModel> tmp = await con.QueryAsync<OutlyingIslandViewModel>("sp_GetOutlyingIslandList", p, commandType: CommandType.StoredProcedure);
                    ret = tmp.ToList<OutlyingIslandViewModel>();
                }
            }
            catch (Exception)
            {
                ret = null;
            }
            return ret;
        }
    }
}