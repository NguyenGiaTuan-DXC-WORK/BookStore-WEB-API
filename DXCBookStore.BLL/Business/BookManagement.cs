using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Filters;
using DXCBookStore.COMMON.Helpers;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.COMMON.Models.ResponseModels;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DXCBookStore.BLL.Business
{
    public class BookManagement : BaseBusiness, IBookManagement
    {
        private IHostingEnvironment _webHostEnvironment;
        private readonly DataContext _db;
        public BookManagement(IHostingEnvironment webHostEnvironment, DataContext db, IConfiguration configuration, IHttpContextAccessor httpContext) : base(httpContext, configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        public async Task<bool> CreateBook(Book book, IFormFile[] photos, int publisherId)
        {
            if(book != null)
            {
                book.PublisherId = publisherId;
                book.CreatedDate = DateTime.Now;
                // Check if book in serie
                if(book.SerieId == 0)
                {
                    book.SerieId = null;
                }
                // Add new book
                _db.Books.Add(book);
                await _db.SaveChangesAsync();

                // Add new image for book
                if (book.Id > 0 && photos != null)
                {
                    var fileHelper = new FileHelper(_webHostEnvironment);
                    foreach (var photo in photos)
                    {
                        var fileName = fileHelper.UploadFile(photo);
                        var image = new Image();
                        image.ImageName = fileName;
                        image.IdBook = book.Id;
                        image.CreatedDate = DateTime.Now;
                        _db.Images.Add(image);
                        await _db.SaveChangesAsync();
                    }
                }
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _db.Books.SingleOrDefaultAsync(x => x.Id == id);
            if(book !=null)
            {
                book.DeletedDate = DateTime.Now;
                _db.Entry(book).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _db.Books.Include(p => p.Images)
                .Include(y => y.Publisher)
                .Include(x => x.Category)
                .Include(z => z.Serie)
                .Where(p => p.DeletedDate == null && p.Category.IsDeleted == false).ToListAsync();
            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
            var result = await _db.Books.Include(p => p.Serie)
                .Include(p => p.Category)
                .Include(p => p.Images)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }

        public async Task<(IEnumerable<Book>, int total)> GetAllBooksByPublisherId(int publisherId, PaginationFilter filter)
        {
            int totalBook = _db.Books.Where(p => p.DeletedDate == null && p.Category.IsDeleted == false && p.PublisherId == publisherId).Count();
            var booksFiltered = await _db.Books.Where(p => p.DeletedDate == null && p.Category.IsDeleted == false && p.PublisherId == publisherId)
                                       .OrderByDescending(p => p.PublishedDate) 
                                       .Skip((filter.PageNumber - 1) * filter.PageSize)
                                       .Take(filter.PageSize)
                                       .ToListAsync();
            return (booksFiltered, totalBook);
        }

        public async Task<IEnumerable<(Book,string)>> GetAllNewestBooks(int num)
        {
            var books = await _db.Books.Include(p => p.Images).OrderByDescending(p => p.PublishedDate).Where(p => p.DeletedDate == null && p.Category.IsDeleted == false).ToListAsync();
            List<(Book, string)> result = new List<(Book, string)>();
            foreach (var book in books)
            {
                var item = (book, book.Images.ToList()[0].ImageName);
                result.Add(item);
            }
            return result;
        }

        public async Task<IEnumerable<(Book,string)>> GetAllStandOutBooks()
        {
            var books = await _db.Books.Include(p => p.Images).OrderByDescending(p => p.PublishedDate).Where(p => p.DeletedDate == null && p.Category.IsDeleted == false).Take(12).ToListAsync();
            List<(Book, string)> result = new List<(Book, string)>();
            foreach (var book in books)
            {
                var item = (book, book.Images.ToList()[0].ImageName);
                result.Add(item);
            }
            return result;
        }

        public async Task<Book> GetDetailBookById(int id)
        {
            var book = await _db.Books.Include(p => p.Serie)
               .Include(p => p.Category)
               .Include(p => p.Images)
               .Include(p => p.Publisher)
               .SingleOrDefaultAsync(i => i.Id == id);

            return book;
        }

        public async Task<bool> UpdateBookQuantity(int id, int quantity)
            {
            var book = await GetBookById(id);   
            book.Quantity = book.Quantity - quantity;
            var result =  await UpdateBook(book);
            return result;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            try
            {
                _db.Entry(book).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksByCategoryId(int id)
        {
            var result = await GetAllBooks();
            if (id !=0)
            {
                return result.Where(x => x.CategoryId == id);
            }
            return result;
        }

        public async Task<IEnumerable<Book>> GetAllBooksBySameAuthor(int bookId, string author)
        {
            var books = await _db.Books.Include(p => p.Images).Where(p => 
            p.DeletedDate == null && p.Category.IsDeleted == false && p.Id != bookId && p.Author.Equals(author)).ToListAsync();

            foreach (var book in books)
            {
                book.Images = book.Images.ToList();
            }
            return books;
        }

        public async Task<IEnumerable<Book>> GetAllBooksByKeyWord(string keyWord)
        {
            if(String.IsNullOrEmpty(keyWord))
            {
                return await _db.Books.Include(p => p.Images)
                .Include(y => y.Publisher)
                .Include(x => x.Category)
                .Include(z => z.Serie)
                .Where(p => p.DeletedDate == null && p.Category.IsDeleted == false).ToListAsync();
            }
            return await _db.Books.Include(p => p.Images)
                .Include(y => y.Publisher)
                .Include(x => x.Category)
                .Include(z => z.Serie)
                .Where(p => p.DeletedDate == null && p.Category.IsDeleted == false && p.Title.ToLower().Trim().Contains(keyWord.ToLower().Trim())).Take(5).ToListAsync();
        }

        public async Task<List<string>> GetAllAuthors()
        {
            var result = await _db.Books.Select(i => i.Author).Distinct().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Book>> GetAllFilteredBooks(FilterRequestModel filter)
        {
            var result = await GetAllBooks();
            if(filter.CategoryId != null)
            {
                result = result.Where(i => i.CategoryId == filter.CategoryId).ToList();
            }
            if(!String.IsNullOrEmpty(filter.Author))
            {
                result = result.Where(i => i.Author.Equals(filter.Author)).ToList();
            }
            if(!String.IsNullOrEmpty(filter.KeyWord))
            {
                result = result.Where(p => p.Title.ToLower().Trim().Contains(filter.KeyWord.ToLower().Trim())).ToList();
            }
            if (filter.PriceStart != null && filter.PriceEnd != null)
            {
                result = result.Where(p => p.Price >= filter.PriceStart && p.Price <= filter.PriceEnd).ToList();
            }
            return result;
        }
    }
}
