using DXCBookStore.COMMON.Models;
using DXCBookStore.BLL.Interfaces;
using DXCBookStore.BLL.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DXC_BookStore_WEB_API.Attributes;
using DXCBookStore.COMMON.Roles;
using DXCBookStore.BLL.Business;
using DXCBookStore.COMMON.Models.RequestModels;

namespace DXC_BookStore_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryManagement _categoryMangagement;
        public CategoryController(ICategoryManagement categoryMangagement)
        {
            _categoryMangagement = categoryMangagement;
        }

        [Produces("application/json")]
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryMangagement.GetAllCategories();

            return Ok(categories.ToListCategoryReponseModel());
        }

        [Produces("application/json")]
        [HttpGet("GetAllParentCategories")]
        public async Task<IActionResult> GetAllParentCategories([FromQuery]int? id = null)
        {
            var categories = await _categoryMangagement.GetAllParentCategories(id);

            return Ok(categories.ToListCategoryReponseModel());
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryRequestModel categoryRequestModel)
        {
            var result = await _categoryMangagement.CreateCategory(categoryRequestModel);
            if (result.Equals("Error"))
            {
                return Ok(new { message = "Tạo danh mục thất bại, vui lòng upload file với định dạng hình ảnh" });
            }
            else if (result.Equals("Fail"))
            {
                return Ok(new { message = "Tạo danh mục thất bại" });
            }
            else
            {
                return Ok(new { message = "Tạo danh mục thành công" });
            }
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryMangagement.DeleteCategory(id);
            return Ok(new { message = "Xóa danh mục thành công" });
        }

    }
}
