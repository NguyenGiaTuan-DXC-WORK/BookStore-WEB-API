using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Entities
{
    public class Invoice:BaseEntity
    {
        public string ShippingAddress { get; set; }
        public string Phone { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PaidDate { get; set; }

        // Dont allow update
        new public DateTime? UpdatedDate
        {
            get { return base.UpdatedDate; }
            set { 
                // Dont Allow Set
                }
        }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
