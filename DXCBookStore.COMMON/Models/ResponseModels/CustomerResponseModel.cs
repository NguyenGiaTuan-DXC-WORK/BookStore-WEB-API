using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Models.ResponseModels
{
    public class CustomerResponseModel:BaseResponseModel
    {
        public string FullName { get; set; }    
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}
