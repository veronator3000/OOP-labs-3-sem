using Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Administrators;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

namespace ApplicationMain.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
    public Administrator? Administrator { get; set; }
}