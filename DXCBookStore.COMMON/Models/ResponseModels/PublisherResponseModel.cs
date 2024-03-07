using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.ResponseModels
{
    public class PublisherResponseModel:BaseResponseModel
    {
        public string BrandName { get; set; }
        public string HeadOfficeAddress { get; set; }
        public string ContactMail { get; set; }
        public string HotLine { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
