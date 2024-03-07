using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Helpers;
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
    public class AdminManagement : IAdminManagement
    {
        private readonly DataContext _db;
        public AdminManagement(DataContext db, IConfiguration configuration)
        {
            _db = db;
        }

        public async Task<Account> GetAdminByUsername(string username)
        {
            var result = await _db.Accounts.SingleOrDefaultAsync(p => p.UserName.ToUpper().Trim().Equals(username.ToUpper().Trim()));
            return result;
        }
    }
}
