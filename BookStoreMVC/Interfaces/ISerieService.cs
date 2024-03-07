using BookStoreMVC.Models;

namespace BookStoreMVC.Interfaces
{
    public interface ISerieService
    {
        IQueryable<Serie> Series { get; }
        public Task<IEnumerable<Serie>> getAllSeries();
    }
}
