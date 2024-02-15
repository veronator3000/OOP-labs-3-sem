using Itmo.ObjectOrientedProgramming.Lab5.Models.Administrators;

namespace Abstractions.Repositories;

public interface IAdminRepository
{
    Task<Administrator?> GetAccess(string password);
}
