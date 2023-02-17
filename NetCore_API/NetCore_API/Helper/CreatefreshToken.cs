using Azure;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Data;
using NetCore_API.Entity;
using System.Security.Cryptography;

namespace NetCore_API.Helper
{
    public class CreatefreshToken
    {


        private readonly DataContext _context;
        private readonly object _httpContextAccessor;

        public CreatefreshToken(DataContext context)
        {
            _context = context;
        }
        public static RefreshTokenModel GenerateRefreshToken()
        {
            var refreshToken = new RefreshTokenModel
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
            return refreshToken;
        }


   
        
    }
}
