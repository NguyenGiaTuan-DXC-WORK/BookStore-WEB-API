using DXCBookStore.COMMON.Entities;
using Microsoft.AspNetCore.Http;
using DXCBookStore.COMMON.Filters;
using DXCBookStore.COMMON.Models.ResponseModels;
using DXCBookStore.COMMON.Models.RequestModels;

namespace DXCBookStore.BLL.Interfaces
{
    public interface IBookManagement
    {
        public Task<IEnumerable<Book>> GetAllBooks();

        public Task<IEnumerable<(Book,string)>> GetAllNewestBooks(int num);

        public Task<IEnumerable<(Book,string)>> GetAllStandOutBooks();

        public Task<(IEnumerable<Book>, int total)> GetAllBooksByPublisherId(int publisherId, PaginationFilter paginationFilter);

        public Task<Book> GetBookById(int id);

        public Task<bool> CreateBook(Book book, IFormFile[] photos, int publisherId);

        public Task<bool> UpdateBook(Book book);

        public Task<bool> DeleteBook(int id);

        public Task<bool> UpdateBookQuantity(int id, int quantity);

        public Task<Book> GetDetailBookById(int id);

        public Task<IEnumerable<Book>> GetAllBooksByKeyWord(string keyWord);

        public Task<IEnumerable<Book>> GetAllBooksByCategoryId(int id);
        public Task<IEnumerable<Book>> GetAllBooksBySameAuthor(int bookId, string author);

        public Task<List<string>> GetAllAuthors();

        public Task<IEnumerable<Book>> GetAllFilteredBooks(FilterRequestModel filter);

    }
}
