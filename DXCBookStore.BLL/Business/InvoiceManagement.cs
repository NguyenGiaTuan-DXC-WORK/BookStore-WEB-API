using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.BLL.Business
{
    public class InvoiceManagement : IInvoiceManagement
    {
        private readonly DataContext _db;
        public InvoiceManagement(DataContext db)
        {
            _db = db;
        }
        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {
            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync();
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoicesByCustomerId(int id)
        {
            var result = await _db.Invoices.Include(p => p.InvoiceDetails).ThenInclude(i => i.Book).ThenInclude(p => p.Images)
                .Include(p=> p.Customer).Where(i => i.CustomerId == id).ToListAsync();
            return result;
        }
    }
}
