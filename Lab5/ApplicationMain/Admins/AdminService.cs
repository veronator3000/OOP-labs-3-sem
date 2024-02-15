using Abstractions.Repositories;
using ApplicationMain.Users;
using Contracts.Administrators;
using Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Administrators;

namespace ApplicationMain.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly CurrentUserManager _currentUser;

    public AdminService(IAdminRepository repository, CurrentUserManager currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<LoginResult> Login(string password)
    {
        Administrator? user = await _repository.GetAccess(password);

        if (user != null)
        {
            _currentUser.Administrator = user;
            return new LoginResult.AdminSuccess();
        }

        return new LoginResult.UserSuccess();
    }
}