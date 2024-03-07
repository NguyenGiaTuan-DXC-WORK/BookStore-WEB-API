using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DXCBookStore.BLL.Interfaces
{
    public interface ISerieManagement
    {
        public Task<IEnumerable<Serie>> GetAllSeries();
        public Task<IEnumerable<Serie>> GetAllSeriesByPublisherId(int id);

        public Task<bool> DeleteSerie(int id);

        public Task<bool> CreateSerie(SerieRequestModel serieRequestModel);

        public Task<bool> UpdateSerie(SerieRequestModel serieRequestMode);

        public Task<Serie> GetSerieById(int id);
    }
}
