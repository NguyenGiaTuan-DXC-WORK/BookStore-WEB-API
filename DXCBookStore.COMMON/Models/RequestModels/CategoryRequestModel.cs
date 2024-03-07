using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.RequestModels
{
    public class CategoryRequestModel
    {
        public string CategoryName { get; set; }
        public int? CategoryParentId { get; set; }
        public IFormFile? CategoryIcon { get; set; }
    }
}
