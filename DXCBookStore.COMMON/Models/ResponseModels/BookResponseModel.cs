using DXCBookStore.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.ResponseModels
{
    public class BookResponseModel:BaseResponseModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string ThumbNail { get; set; }

        public string Author { get; set; }

        // New
        public List<Image> Images { get; set; }
        public string Publisher { get; set; }
        public string? SerieName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
