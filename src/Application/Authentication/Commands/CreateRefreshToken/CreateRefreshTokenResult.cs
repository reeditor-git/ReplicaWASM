namespace Replica.Application.Authentication.Commands.CreateRefreshToken
{
    public class CreateRefreshTokenResult
    {
        public string RefreshToken { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
