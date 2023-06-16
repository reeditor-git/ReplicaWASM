namespace Replica.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public string? Secret { get; set; }

        public int TokenExpiryTime { get; set; }

        public int RefreshTokenExpiryTime { get; set; }

        public string? Issuer { get; set; }

        public string? Audience { get; set; }
    }
}
