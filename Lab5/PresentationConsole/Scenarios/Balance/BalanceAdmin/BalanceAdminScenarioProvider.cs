using System.Diagnostics.CodeAnalysis;
using Contracts.Administrators;
using Contracts.Users;

namespace PresentationConsole.Scenarios.Balance.BalanceAdmin;

public class BalanceAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentUserService _currentUser;
    private readonly IUserService _userService;

    public BalanceAdminScenarioProvider(
        IAdminService adminService,
        ICurrentUserService currentUser,
        IUserService userService)
    {
        _adminService = adminService;
        _currentUser = currentUser;
        _userService = userService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.Administrator is null)
        {
            scenario = null;
            return false;
        }

        scenario = new BalanceAdminScenario(_adminService, _userService);
        return true;
    }
}