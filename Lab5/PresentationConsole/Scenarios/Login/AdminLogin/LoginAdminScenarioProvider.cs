using System.Diagnostics.CodeAnalysis;
using Contracts.Administrators;
using Contracts.Users;

namespace PresentationConsole.Scenarios.Login.AdminLogin;

public class LoginAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentUserService _currentUser;

    public LoginAdminScenarioProvider(
        IAdminService adminService,
        ICurrentUserService currentUser)
    {
        _adminService = adminService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.Administrator is not null || _currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginAdminScenario(_adminService);
        return true;
    }
}