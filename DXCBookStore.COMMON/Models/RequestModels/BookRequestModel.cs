using DXCBookStore.COMMON.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.RequestModels
{
    public class BookRequestModel:BaseRequestModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? SerieId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int Quantity { get; set; }
        public IFormFile[] Images { get; set; }

        public int TotalPage { get; set; }

        public string Author { get; set; }
    }
}
