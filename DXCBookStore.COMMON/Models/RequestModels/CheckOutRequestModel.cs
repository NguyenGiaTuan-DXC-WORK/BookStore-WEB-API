using DXCBookStore.COMMON.Models.ResponseModels;
using DXCBookStore.COMMON.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.RequestModels
{
    public class CheckOutRequestModel
    {
        public List<CartItem> Cart { get; set; }
        public CustomerResponseModel Customer { get; set; }
    }
}
