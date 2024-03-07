using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.COMMON.Helpers
{
    public class RandomPassWordHelper
    {
        public static int RandomPassWord()
        {
            Random rnd = new Random();
            var randomPassword = rnd.Next(100000, 999999);
            return randomPassword; 
        }
    }
}
