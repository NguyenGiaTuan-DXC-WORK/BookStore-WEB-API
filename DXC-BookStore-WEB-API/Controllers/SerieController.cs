using DXCBookStore.BLL.Business;
using DXCBookStore.BLL.Interfaces;
using DXCBookStore.BLL.Mapper;
using DXCBookStore.COMMON.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXC_BookStore_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private ISerieManagement _serieManagement;
        public SerieController(ISerieManagement serieManagement)
        {
            _serieManagement = serieManagement;
        }

        [Produces("application/json")]
        [HttpGet("GetAllSeries")]
        public async Task<IActionResult> GetAllSeries()
        {
            var series = await _serieManagement.GetAllSeries();
            return Ok(series.ToListSerieResponseModel());
        }

        [Produces("application/json")]
        [HttpGet("GetAllSeriesByPublisherId/{id}")]
        public async Task<IActionResult> GetAllSeriesByPublisherId(int id)
        {
            var series = await _serieManagement.GetAllSeriesByPublisherId(id);
            return Ok(series.ToListSerieResponseModel());
        }

        [HttpPost("CreateSerie")]
        public async Task<IActionResult> CreateSerie([FromForm] SerieRequestModel serieRequestModel)
        {
            var result = await _serieManagement.CreateSerie(serieRequestModel);
            if(result)
            {
                return Ok(new { message = "Tạo mới serie thành công" });
            }
            return Ok(new {message = "Tạo mới serie thất bại"});
        }

        [HttpPut("UpdateSerie")]
        public async Task<IActionResult> UpdateSerie([FromForm] SerieRequestModel serieRequestModel)
        {
            var result = await _serieManagement.UpdateSerie(serieRequestModel);
            if(result)
            {
                return Ok(new { message = "Cập nhật serie thành công" });
            }
            return Ok(new { message = "Cập nhật serie thất bại" });
        }

        [HttpDelete("DeleteSerie/{id}")]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            var result = await _serieManagement.DeleteSerie(id);
            return Ok(new { message = "Xóa serie thành công" });
        }
    }
}
