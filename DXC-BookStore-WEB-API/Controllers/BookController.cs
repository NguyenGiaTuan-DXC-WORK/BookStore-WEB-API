using DXC_BookStore_WEB_API.Attributes;
using DXCBookStore.BLL.Interfaces;
using DXCBookStore.BLL.Mapper;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.COMMON.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXC_BookStore_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookManagement _bookManagement;
        public BookController(IBookManagement bookManagement)
        {
            _bookManagement = bookManagement;
        }   

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookManagement.GetAllBooks();

            return Ok(books.ToListBookResponseModel());
        }

        [Produces("application/json")]  
        [HttpGet("GetAllBooksByKeyword/{keyword?}")]
        public async Task<IActionResult> GetAllBooksByKeyword(string? keyword)
        {
            var books = await _bookManagement.GetAllBooksByKeyWord(keyword);
            return Ok(books.ToListBookResponseModel());
        }

        [Produces("application/json")]
        [HttpGet("GetBookDetailById/{id}")]
        public async Task<IActionResult> GetBookDetailById(int id)
        {
            var book = await _bookManagement.GetDetailBookById(id);
            return Ok(book.ToBookResponseModel());
        }

        [Produces("application/json")]
        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _bookManagement.GetAllAuthors();
            return Ok(authors);
        }

        [HttpPost("GetAllFilteredBooks")]
        public async Task<IActionResult> GetAllFilteredBooks([FromBody] FilterRequestModel filter)
        {
            var books = await _bookManagement.GetAllFilteredBooks(filter);
            return Ok(books.ToListBookResponseModel());
        }
    }
}
