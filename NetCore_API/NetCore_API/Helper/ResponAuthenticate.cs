using Azure.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using NetCore_API.Data;
using NetCore_API.Entity;
using NetCore_API.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace NetCore_API.Helper
{
    public class ResponAuthenticate
    {
        private readonly DataContext _context;
        public ResponAuthenticate(DataContext context)
        {
            _context = context;
        }
        private readonly IConfiguration _configuration;

        public ResponAuthenticate(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        public static string CreateToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, account.Email),
                 new Claim(ClaimTypes.Role,account.Role),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(HashPassword.secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            issuer: "your_issuer",
            audience: "your_audience",
            claims: claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: creds
        );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string RefreshToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, account.Email),
                 new Claim(ClaimTypes.Role,account.Role),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(HashPassword.secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            issuer: "your_issuer",
            audience: "your_audience",
            claims: claims,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: creds
        );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string DeleteToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, account.Email),
                 new Claim(ClaimTypes.Role,account.Role),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(HashPassword.secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            issuer: "your_issuer",
            audience: "your_audience",
            claims: claims,
            expires: DateTime.Now,
            signingCredentials: creds
        );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public static string CheckExpireToken()
        //{
        //    var handler = new JwtSecurityTokenHandler();
           
        //    string jwt = Request.Headers["Authorization"];

        //    if (string.IsNullOrEmpty(jwt))
        //    {
        //        return "Authorization header is missing.";
        //    }

        //    if (!jwt.StartsWith("Bearer "))
        //    {
        //        return "Authorization header is not a bearer token.";
        //    }

        //    jwt = jwt.Substring(7);
        //    var token = handler.ReadToken(jwt) as JwtSecurityToken;

        //    if (token.ValidTo.ToLocalTime() < DateTime.Now)
        //    {
        //        return "Unauthorized()";
        //    }
        //    return jwt;
        //}



        public void Logout()
        {
            JwtSecurityTokenHandler.DefaultInboundClaimFilter.Clear();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
        }
    }
}
