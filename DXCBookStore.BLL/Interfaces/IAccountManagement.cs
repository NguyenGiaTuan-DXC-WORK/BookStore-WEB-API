using DXCBookStore.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXCBookStore.BLL.Interfaces
{
    public interface IAccountManagement
    {
        public Task<bool> CreateAccount(Account account);
        public Task<bool> UpdateAccount(Account account);

        public Task<string> LoginAccount(string username, string password);

        public Task<Account> GetAccountByUserName(string userName);

        public Task<bool> CheckExistUserName(string userName);

    }
}
