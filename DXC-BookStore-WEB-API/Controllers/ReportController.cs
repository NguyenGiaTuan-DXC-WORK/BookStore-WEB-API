using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Helpers;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.COMMON.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXC_BookStore_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportManagement _reportManagement;
        public ReportController(IReportManagement reportManagement) {
            _reportManagement = reportManagement;
        }
        [HttpPost("GetAllReportByBrand")]
        public async Task<IActionResult> GetAllReportByBrand([FromBody] ReportRequestItem item)
        {
            var result = await _reportManagement.getAllReportByBrand(item);
            return Ok(result);
        }

        [HttpPost("GetRevenueReportByPublisher")]
        public async Task<IActionResult> GetRevenueReportByPublisher([FromBody] RevenueReportRequest item)
        {
            var result = await _reportManagement.getRevenueReportByPublisherId(item);
            return Ok(result);
        }

        [HttpPost("GetRevenueReportByDateRange")]
        public async Task<IActionResult> GetRevenueReportByDateRange([FromBody] DateRangeRequestModel item)
        {
            var result = await _reportManagement.getRevenueReportByDateRange(item);

            return Ok(result.ToFullDate(item.StartDate, item.EndDate));
        }
    }
}
