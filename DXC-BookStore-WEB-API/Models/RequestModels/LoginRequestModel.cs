using System.ComponentModel.DataAnnotations;

namespace DXC_BookStore_WEB_API.Models.RequestModels
{
    public class LoginRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
