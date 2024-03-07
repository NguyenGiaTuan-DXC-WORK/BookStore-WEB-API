using DXCBookStore.COMMON.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DXCBookStore.BLL.Business
{
    public class BaseBusiness
    {
        protected IHttpContextAccessor _contextAccessor;
        protected IConfiguration _configuration;
        public BaseBusiness(IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }

        public Account CurrentUser
        {
            get
            {
                if (!_contextAccessor.HttpContext.User.Identity.IsAuthenticated) return null;
                var identity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    string userName = identity?.FindFirst(ClaimTypes.Email)?.Value;
                    string userRole = identity.FindFirst(ClaimTypes.Role).Value;
                    int userId = int.Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    return new Account()
                    {
                        UserName = userName,
                        Role = userRole,
                        Id = userId
                    };
                }
                return null;
            }
        }

    }
}

