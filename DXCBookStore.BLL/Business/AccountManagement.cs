using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Helpers;
using DXCBookStore.COMMON.Roles;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Security.Claims;

namespace DXCBookStore.BLL.Business
{
    public class AccountManagement:BaseBusiness, IAccountManagement
    {
        private readonly DataContext _db;
        public AccountManagement(DataContext db, IConfiguration configuration, IHttpContextAccessor contextAccessor):base(contextAccessor, configuration)
        {
            _db = db;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> CheckExistUserName(string userName)
        {
            var result = await _db.Accounts.SingleOrDefaultAsync(p => p.UserName.ToLower().Trim().Equals(userName.ToLower().Trim()));
            if(result != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> CreateAccount(Account account)
        {
            try
            {
				_db.Accounts.Add(account);
				var result = await _db.SaveChangesAsync();

				if (result > 0)
				{
					return true;
				}
			}
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;

        }
       
        public async Task<Account> GetAccountByUserName(string userName)
        {
            var result = await _db.Accounts.SingleOrDefaultAsync(p => p.UserName.ToUpper().Trim().Equals(userName.ToUpper().Trim()));
            if(result != null)
            {
                if (result.Role == UserRole.Customer)
                {
                    result = await _db.Accounts.Include(p => p.Customer).SingleOrDefaultAsync(p => p.Id == result.Id);
                }
                else if (result.Role == UserRole.Publisher)
                {
                    result = await _db.Accounts.Include(p => p.Publisher).SingleOrDefaultAsync(p => p.Id == result.Id);
                }
            }
            return result;
        }

        public async Task<string> LoginAccount(string username, string password)
        {
            var validAccount = await GetAccountByUserName(username);
            if (validAccount != null)
            {
                var validAdminPassword = BCrypt.Net.BCrypt.Verify(password, validAccount.PassWord);
                if (validAdminPassword)
                {
                    if (validAccount != null)
                    {
                        var jwtHelper = new JwtHelper(_configuration);
                        string token = "";

                        string fullName = "";
                        if(validAccount.Role == UserRole.Customer)
                        {
                            fullName = validAccount.Customer.FullName;
                        }
                        else if(validAccount.Role == UserRole.Publisher)
                        {
                            fullName = validAccount.Publisher.BrandName;
                        }
                        else
                        {
                            fullName = "admin";
                        }

                        token = jwtHelper.CreateJwtToken(validAccount.UserName, validAccount.Id.ToString(), validAccount.Role, fullName);

                        var identity = new ClaimsIdentity(new List<Claim>
                        {
                            new Claim("UserId", validAccount.Id.ToString(), ClaimValueTypes.Integer32),
                            new Claim("UserRole", validAccount.Role, ClaimValueTypes.String),
                            new Claim("UserName", validAccount.UserName, ClaimValueTypes.String)
                        }, "Custom");

                        return token;
                    }
                }
            }
            return null;
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            _db.Entry(account).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            if(result > 0 )
            {
                return true;
            }
            return false;
        }
    }
}
