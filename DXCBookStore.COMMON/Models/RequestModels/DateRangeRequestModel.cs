using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.RequestModels
{
    public class DateRangeRequestModel
    {
        public string StartDate { get;set; }
        public string EndDate { get;set; }
        public int PublisherId { get; set; }    
    }
}
