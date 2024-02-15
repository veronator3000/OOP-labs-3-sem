using Itmo.ObjectOrientedProgramming.Lab5.Models.Administrators;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

namespace Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
    Administrator? Administrator { get; }
}