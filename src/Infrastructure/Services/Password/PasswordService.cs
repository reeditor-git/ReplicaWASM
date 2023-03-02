using System.Security.Cryptography;
using System.Text;

namespace Replica.Infrastructure.Services.Password
{
    public class PasswordService
    {
        public readonly string Hash;
        public PasswordService(string password)
        {

            byte[] hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new();

            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }

            Hash = builder.ToString();
        }
    }
}
