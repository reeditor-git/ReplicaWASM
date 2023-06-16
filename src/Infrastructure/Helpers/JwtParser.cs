using Replica.Application.Common.Interfaces.Helpers;
using System.Security.Claims;
using System.Text.Json;

namespace Replica.Infrastructure.Helpers
{
    public class JwtParser : IJwtParser
    {
        public IEnumerable<Claim> JwtParseClaim(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = Base64Parse(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private byte[] Base64Parse(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
