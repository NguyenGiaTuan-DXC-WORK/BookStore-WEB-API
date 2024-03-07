using DXCBookStore.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.BLL.Interfaces
{
    public interface IInvoiceDetailManagement
    {
        public Task<bool> CreateInvoiceDetail(InvoiceDetail invoiceDetail);
        public Task<IEnumerable<InvoiceDetail>> GetInvoiceDetailsByInvoiceId(int id);

        public Task<IEnumerable<InvoiceDetail>> GetInvoiceDetailsByPublisherId(int id);

    }
}
