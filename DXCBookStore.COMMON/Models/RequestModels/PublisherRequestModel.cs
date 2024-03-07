using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.RequestModels
{
    public class PublisherRequestModel
    {
        public string BrandName { get; set; }
        public string HeadOfficeAddress { get; set; }
        public string ContactMail { get; set; }
        public string HotLine { get; set; }
        public string Description { get; set; }
    }
}
