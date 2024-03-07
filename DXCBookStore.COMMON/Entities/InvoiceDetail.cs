using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public int BookId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }
        public int Quantity { get; set; }

        public virtual Book Book { get; set; }
        [JsonIgnore]
        public virtual Invoice Invoice { get; set; }
    }
}
