using System.ComponentModel.DataAnnotations;

namespace NetCore_API.Model
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User";
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }

}
