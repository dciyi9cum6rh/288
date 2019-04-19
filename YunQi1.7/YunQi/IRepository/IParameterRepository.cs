using DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IParameterRepository
    {
        string constr { get; set; }

        Task<List<ParameterViewModel>> GetParameterList();

        Task<int> UpdateParameter(string ParameterId, string ParameterValue);

        Task<List<DevelopmentBonusViewModel>> GetDevelopmentBonusList();

        Task<int> UpdateDevelopmentBonus(string DevelopmentBonusId, string DevelopmentBonusLimit, string DevelopmentBonusValue);

        Task<List<FreightViewModel>> GetFreightList();

        Task<int> UpdateFreight(string FreightId, string FreightLimit, string FreightValue);

        Task<YoutubeVideoViewModel> GetYoutubeVideoList();

        Task<int> UpdateYoutubeVideo(int YoutubeVideoId, string YoutubeVideo);

        Task<OrderFreightViewModel> GetOrderFreight(decimal ProductFee);

        Task<List<OutlyingIslandViewModel>> GetOutlyingIslandList();
    }
}