using DXCBookStore.BLL.Interfaces;
using DXCBookStore.BLL.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXC_BookStore_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceManagement _invoiceManagement;
        public InvoiceController(IInvoiceManagement invoiceManagement)
        {
            _invoiceManagement = invoiceManagement;
        }
        [Produces("application/json")]
        [HttpGet("GetAllInvoicesByCustomerId/{id}")]
        public async Task<IActionResult> GetAllInvoicesByCustomerId(int id)
        {
            var result = await _invoiceManagement.GetAllInvoicesByCustomerId(id);
            if (result != null)
            {
                return Ok(result.ToListInvoiceReponseModel());
            }
            return Ok("Invalid");
        }
    }
}
