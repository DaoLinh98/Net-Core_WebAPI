using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_API.Entity
{

    [Table("Accounts")]
    public class Account
    {

        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        public string Email { get; set; }

        [MaxLength(256)]
        public string Password { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; } = string.Empty;
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
      

            //public string? Role { get; set; }
        }
}
