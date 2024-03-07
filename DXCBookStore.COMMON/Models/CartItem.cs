using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Models.ResponseModels;

namespace DXCBookStore.COMMON.ViewModels
{
    public class CartItem
    {
        public int Quantity { get; set; }   
        public BookResponseModel Book { get; set; }
    }
}
