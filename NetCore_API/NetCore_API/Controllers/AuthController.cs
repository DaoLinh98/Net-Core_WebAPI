using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NetCore_API.Data;
using NetCore_API.Entity;
using NetCore_API.Helper;
using NetCore_API.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace NetCore_API.Controllers
{
    [Route("api/Authenticate")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            if (_context.Accounts.FirstOrDefault(x => x.Email == request.Email) != null)
            {
                return BadRequest("email is exit!");
            }

            var account = new Account
            {
                Email = request.Email,
                Password = HashPassword.CreatePasswordHash(request.Password),
                Role = (request.Role == null || request.Role == string.Empty || request.Role != "Admin" || request.Role != "User") ? "User" : request.Role,
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return Ok(account);
        }



        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (_context.Accounts.FirstOrDefault(x => x.Email == request.Email) == null)
            {
                return BadRequest("email not found!");
            }
            var account = _context.Accounts.FirstOrDefault(x => x.Email == request.Email);
            if (account.Password != HashPassword.CreatePasswordHash(request.Password))
            {
                return BadRequest("Password incorrect");
            }
            string token = ResponAuthenticate.CreateToken(account);
            account.Token = token;
            _context.SaveChanges(); 
            return Ok(new
            {
                Token = token,
                emailLoged = account.Email
            });
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken(string emailLoged)
        {

            if (_context.Accounts.FirstOrDefault(x => x.Email == emailLoged) == null)
            {
                return BadRequest("Email is not correct");
            }
            var account = _context.Accounts.FirstOrDefault(x => x.Email == emailLoged);
            string token = ResponAuthenticate.RefreshToken(account);
            account.Token= token;
            _context.SaveChanges();
            
            return Ok(new
            {
                Token = token,
            }); 
        }

        [HttpPost("logout")]
        public IActionResult Logout(string emailLoged)
        {


            if (_context.Accounts.FirstOrDefault(x => x.Email == emailLoged) == null)
            {
                return BadRequest("email not found!");
            }
            var account = _context.Accounts.FirstOrDefault(x => x.Email == emailLoged);
            string token = ResponAuthenticate.DeleteToken(account);

            return Ok(new
            {
                Token = token,
            });
        }
        private void SetRefreshToken(RefreshTokenModel newrefreshToken, Account account)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newrefreshToken.Expires,
            };
            Response.Cookies.Append("refreshToken", newrefreshToken.Token, cookieOptions);
            account.RefreshToken = newrefreshToken.Token;
            account.TokenCreated = newrefreshToken.Created;
            account.TokenExpires = newrefreshToken.Expires;
            _context.SaveChanges();
        }
    }
}
