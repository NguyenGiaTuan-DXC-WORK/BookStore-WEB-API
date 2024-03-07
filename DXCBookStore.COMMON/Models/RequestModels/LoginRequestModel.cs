using System.ComponentModel.DataAnnotations;

namespace DXCBookStore.COMMON.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
