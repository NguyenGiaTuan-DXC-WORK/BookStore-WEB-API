using DXCBookStore.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.BLL.Interfaces
{
    public interface IInvoiceManagement
    {
        public Task<Invoice> CreateInvoice(Invoice invoice);

        public Task<IEnumerable<Invoice>> GetAllInvoicesByCustomerId(int id); 
    }
}
