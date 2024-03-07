using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Entities
{
    public class Customer:BaseEntity
    {
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public int? Gender { get; set; }
        public string ShippingAddress { get; set; } 
        public virtual Account Account { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
