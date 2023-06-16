using Replica.Application.Common.Interfaces.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace Replica.Infrastructure.Helpers
{
    public class CryptoPassword : ICryptoPassword
    {
        public string HashPassword(string password)
        {
            byte[] hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new();

            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
