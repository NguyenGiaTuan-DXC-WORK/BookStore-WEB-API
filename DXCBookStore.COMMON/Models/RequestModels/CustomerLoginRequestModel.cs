using System.ComponentModel.DataAnnotations;

namespace DXCBookStore.COMMON.Models
{
    public class CustomerLoginRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
