using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.ResponseModels
{
    public class InvoiceDetailResponseModel:BaseResponseModel
    {
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ThumbNail { get; set; }
        public string Author { get; set; }
    }
}
