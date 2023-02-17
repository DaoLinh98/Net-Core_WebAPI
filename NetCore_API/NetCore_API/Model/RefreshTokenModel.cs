using System.Security.Cryptography;

namespace NetCore_API.Helper
{
    public  class RefreshTokenModel
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
