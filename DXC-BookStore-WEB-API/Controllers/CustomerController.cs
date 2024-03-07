using DXCBookStore.BLL.Interfaces;
using DXCBookStore.BLL.Mapper;
using DXCBookStore.BLL.PayPal;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.COMMON.Models.ResponseModels;
using DXCBookStore.COMMON.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXC_BookStore_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerManagement _customerManagement;
        private IConfiguration _configuration;

        public CustomerController(ICustomerManagement customerManagement, IConfiguration configuration)
        {
            _customerManagement = customerManagement;
            _configuration = configuration;
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegisterRequestModel customer)
        {
            var result = await _customerManagement.CustomerRegister(customer);
            if(result)
            {
                return Ok(new {message = "Success"});
            }
            else
            {
                return Ok(new {message = "Invalid"});
            }
        }


        [Produces("application/json")]
        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _customerManagement.GetCustomerById(id);
            if(result != null )
            {
                return Ok(result.ToCustomerResponseModel());
            }
            return Ok("Invalid");
        }

        [HttpGet("CheckOut/{total}")]
        [Produces("application/json")]
        public async Task<ActionResult> CheckOut(double total)
        {
            var payPalAPI = new PayPalAPI(_configuration);  
            string url = await payPalAPI.getRedirectURLToPayPal(total, "USD");
            return Ok(url);
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("CustomerPayPalSuccess")]
        public async Task<ActionResult> CustomerPayPalSuccess([FromBody] CheckOutRequestModel checkOutRequest)
        {
            var msg = await _customerManagement.CustomerCheckOut(checkOutRequest.Cart, checkOutRequest.Customer);
            return Ok(msg);
        }

    }
}
