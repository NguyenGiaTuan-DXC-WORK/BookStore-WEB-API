using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.RequestModels
{
    public class RevenueReportRequest
    {
        public int PublisherId { get; set; }
        public int Year { get; set; }
    }
}
