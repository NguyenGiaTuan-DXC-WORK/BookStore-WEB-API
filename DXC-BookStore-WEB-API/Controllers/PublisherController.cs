using DXCBookStore.BLL.Interfaces;
using DXCBookStore.BLL.Mapper;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXC_BookStore_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public IPublisherManagement _publisherManagement;
        public PublisherController(IPublisherManagement publisherManagement)
        {
            _publisherManagement = publisherManagement;
        }

        [HttpGet("GetAllInActivePublishers")]
        public async Task<IActionResult> GetAllInActivePublishers()
        {
            var publishers = await _publisherManagement.GetAllInActivePublisher();
            return Ok(publishers.ToListPublisherResponseModel());
        }

        [HttpGet("GetAllActivePublishers")]
        public async Task<IActionResult> GetAllActivePublishers()
        {
            var publishers = await _publisherManagement.GetAllActivePublisher();
            return Ok(publishers.ToListPublisherResponseModel());
        }

        [HttpGet("ActivePublisher/{id}")]
        public async Task<IActionResult> ActivePublisher(int id)
        {
            var result = await _publisherManagement.ActivatePublisher(id);
            return Ok(new {message = "Cấp quyền truy cập cho nhà xuất bản thành công"});
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(PublisherRequestModel publisherRequestModel)
        {
            var publisher = publisherRequestModel.ToPublisherModel();
            if (await _publisherManagement.CreatePublisher(publisher))
            {
                return Ok(new {message = "Đăng ký trở thành nhà xuất bản thành công !"});
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
