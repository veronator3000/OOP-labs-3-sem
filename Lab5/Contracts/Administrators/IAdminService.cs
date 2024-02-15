using Contracts.Users;

namespace Contracts.Administrators;

public interface IAdminService
{
    Task<LoginResult> Login(string password);
}