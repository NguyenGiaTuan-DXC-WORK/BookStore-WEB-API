using System.ComponentModel.DataAnnotations;

namespace DXCBookStore.COMMON.Models;

public class RegisterViewModel
{
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string ShippingAddress { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string PassWord { get; set; }
}
