using DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IMediaRepository
    {
        string constr { get; set; }

        Task<long> GetHomeImageListCount();

        Task<List<HomeImageViewModel>> GetHomeImageList(int Skip, int RowsPerPage);

        Task<int> InsertHomeImage(string FileName, byte[] PictureContent, string PictureType, string HomeImageDescription);

        Task<HomeImageViewModel> GetOneHomeImage(int HomeImageId);

        Task<int> UpdateHomeImage(string FileName, byte[] PictureContent, string PictureType, string HomeImageDescription, int HomeImageId);

        Task<int> DeleteHomeImage(int HomeImageId);

        Task<long> GetMallImageListCount();

        Task<List<MallImageViewModel>> GetMallImageList(int Skip, int RowsPerPage);

        Task<int> InsertMallImage(string FileName, byte[] PictureContent, string PictureType, string MallImageDescription);

        Task<MallImageViewModel> GetOneMallImage(int MallImageId);

        Task<int> UpdateMallImage(string FileName, byte[] PictureContent, string PictureType, string MallImageDescription, int MallImageId);

        Task<int> DeleteMallImage(int MallImageId);
    }
}