namespace Replica.Application.Common.Interfaces.Helpers
{
    public interface IPasswordService
    {
        string HashPassword(string password);
    }
}
