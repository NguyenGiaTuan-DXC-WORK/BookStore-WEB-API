using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.RequestModels
{
    public class SerieRequestModel:BaseRequestModel
    {
        public string SerieName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public IFormFile? Thumbnail { get; set; }
        public int PublisherId { get; set; }
    }
}
