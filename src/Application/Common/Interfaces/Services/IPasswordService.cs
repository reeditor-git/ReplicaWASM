namespace Replica.Application.Common.Interfaces.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
    }
}