using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.RequestModels
{
    public class FilterRequestModel
    {
        public int? CategoryId { get; set; }    
        public string? Author { get; set; }  
        public string? KeyWord { get; set; }
        public decimal? PriceStart { get; set; }
        public decimal? PriceEnd { get; set; }
    }
}
