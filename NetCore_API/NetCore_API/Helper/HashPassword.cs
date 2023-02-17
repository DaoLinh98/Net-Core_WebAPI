using System.Security.Cryptography;
using System.Text;

namespace NetCore_API.Helper
{
    public class HashPassword
    {
        public static string CreatePasswordHash(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes;

            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(passwordBytes);
            }

            string hash = BitConverter.ToString(hashBytes);
            return hash;
        }

        public static string secretKey = "mykeyasasaananannanannanannan";


   
    }



}
