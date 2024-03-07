using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Entities
{
    public class Account:BaseEntity
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        
        public DateTime? LastLoggedIn { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
