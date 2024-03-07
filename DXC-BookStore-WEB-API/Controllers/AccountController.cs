using DXCBookStore.COMMON.Models;
using DXCBookStore.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DXC_BookStore_WEB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IAccountManagement _accountManagement;
        public AccountController(IAccountManagement accountManagement)
        {
            _accountManagement = accountManagement;
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginRequestModel loginRequestModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var token = await _accountManagement.LoginAccount(loginRequestModel.UserName, loginRequestModel.Password);
                    if (token != null)
                    {
                        return Ok(token);
                    }
                    else
                    {
                        return Ok("Invalid");
                    }
                }
                catch (Exception e )
                {
                    
                }
            }
            return BadRequest(ModelState);
        }
    }
}
