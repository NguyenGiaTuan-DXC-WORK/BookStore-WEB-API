using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DXCBookStore.COMMON.Helpers
{
    public class JwtHelper
    {
        public IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateJwtToken(string username, string userId, string role, string fullName)
        {
            var secretKey = _configuration.GetSection("AppSettings:Token").Value!;
            var expireTime = int.Parse(_configuration.GetSection("AppSettings:Expire").Value!);
            // Tạo các thông tin về người dùng (claims)
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Email, username),
                new Claim(ClaimTypes.Name, fullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Khóa bí mật sử dụng để ký (sign) token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Tạo token
            var token = new JwtSecurityToken(
                issuer: "DXC",
                audience: "User",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireTime), // Thời     gian hết hạn của token (1 phut)
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // Chuyển đổi token thành chuỗi
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
