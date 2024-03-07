using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.BLL.Business
{
    public class InvoiceDetailManagement : IInvoiceDetailManagement
    {
        private readonly DataContext _db;
        public InvoiceDetailManagement(DataContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            _db.InvoiceDetails.Add(invoiceDetail);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<InvoiceDetail>> GetInvoiceDetailsByInvoiceId(int id)
        {
            var result = await _db.InvoiceDetails
                .Include(p => p.Book)
                .ThenInclude(i => i.Images)
                .Include(p => p.Book)
                .ThenInclude(x => x.Category)
                .Where(i => i.InvoiceId == id).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<InvoiceDetail>> GetInvoiceDetailsByPublisherId(int id)
        {
            var result = await _db.InvoiceDetails
                .Include(p => p.Book)
                .ThenInclude(i => i.Images)
                .Include(p => p.Book)
                .ThenInclude(x => x.Category)
                .Where(i => i.Book.Publisher.Id == id).ToListAsync();
            return result;
        }
    }
}
