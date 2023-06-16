namespace Replica.Application.Common.Interfaces.Helpers
{
    public interface ICryptoPassword
    {
        string HashPassword(string password);
    }
}
