using DXCBookStore.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.ResponseModels
{
    public class SerieResponseModel:BaseResponseModel
    {
        public string SerieName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public bool? IsDeleted { get; set; }

        public string Thumbnail { get; set; }
    }
}
