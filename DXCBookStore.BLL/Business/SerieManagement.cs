using DXCBookStore.BLL.Interfaces;
using DXCBookStore.BLL.Mapper;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Helpers;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DXCBookStore.BLL.Business
{
    public class SerieManagement : ISerieManagement
    {
        private readonly DataContext _db;
        private IHostingEnvironment _webHostEnvironment;
        public SerieManagement(DataContext db,IHostingEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        public async Task<bool> CreateSerie(SerieRequestModel serieRequestModel)
        {
            // Check null serie
            if (serieRequestModel != null)
            {
                // Save new serie
                var serie = serieRequestModel.ToSerieModel();
                var result = _db.Series.Add(serie);
                await _db.SaveChangesAsync();
                // Check is save success and have thumbnail
                if (serie.Id > 0 && serieRequestModel.Thumbnail != null)
                {
                    var fileHelper = new FileHelper(_webHostEnvironment);
                    // Save image for serie
                    // Modify file name
                    var fileName = fileHelper.UploadFile(serieRequestModel.Thumbnail);
                    var image = new Image();
                    image.ImageName = fileName;
                    image.IdSerie = serie.Id;
                    image.CreatedDate = DateTime.Now;
                    var newImage = _db.Add(image);
                    await _db.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSerie(int id)
        {
            var serie = await GetSerieById(id);
            if (serie != null)
            {
                _db.Series.Remove(serie);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

        public async Task<IEnumerable<Serie>> GetAllSeries()
        {
            var series = await _db.Series.OrderByDescending(p=> p.Id).Include(p => p.Image).ToListAsync();
            return series;
        }

        public async Task<IEnumerable<Serie>> GetAllSeriesByPublisherId(int id)
        {
            var series = await _db.Series.OrderByDescending(p => p.Id).Include(p => p.Image).Where(i => i.PublisherId == id).ToListAsync();
            return series;
        }

        public async Task<Serie> GetSerieById(int id)
        {
            var serie = await _db.Series.Include(p => p.Image).SingleOrDefaultAsync(p => p.Id == id);
            if (serie != null)
            {
                return serie;
            }
            return null;
        }

        public async Task<bool> UpdateSerie(SerieRequestModel serieRequestModel)
        {
            // Get original serie
            var serie = _db.Series.Include(p => p.Image).SingleOrDefault(p => p.Id == serieRequestModel.Id);

            // Update serie
            serie.SerieName = serieRequestModel.SerieName;
            serie.StartYear = serieRequestModel.StartYear;
            serie.EndYear = serieRequestModel.EndYear;
            serie.IsDeleted = serieRequestModel.IsDeleted;

            // Check if it is new thumbnail
            if ( serieRequestModel.Thumbnail !=null && !serieRequestModel.Thumbnail.Name.Equals(serie.Image.ImageName))
            {
                var fileHelper = new FileHelper(_webHostEnvironment);
                // Delete old file
                fileHelper.DeleteOldFile(serie.Image.ImageName);

                // Upload new file
                var fileName = fileHelper.UploadFile(serieRequestModel.Thumbnail);

                // Update image
                serie.Image.ImageName = fileName;
                serie.Image.UpdatedDate = DateTime.Now;

                _db.Entry(serie.Image).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            // Update date modify
            serie.UpdatedDate = DateTime.Now;
            _db.Entry(serie).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
