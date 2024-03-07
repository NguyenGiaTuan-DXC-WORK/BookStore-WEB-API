using System.ComponentModel.DataAnnotations;

namespace DXC_BookStore_WEB_API.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
