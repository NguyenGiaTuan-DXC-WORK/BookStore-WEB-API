using BookStoreMVC.DatabaseContext;
using BookStoreMVC.Interfaces;
using BookStoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMVC.Services
{
    public class SerieService : ISerieService
    {
        private DataContext _db;
        public SerieService(DataContext db) 
        { 
            _db = db;
        }

        public IQueryable<Serie> Series => _db.Set<Serie>();

        public async Task<IEnumerable<Serie>> getAllSeries()
        {
            return await _db.Set<Serie>().ToListAsync();
        }
    }
}
