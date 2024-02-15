using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace PresentationConsole.Scenarios.Balance.BalanceUser;

public class BalanceUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public BalanceUserScenarioProvider(
        IUserService userService,
        ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new BalanceUserScenario(_userService);
        return true;
    }
}