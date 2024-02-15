using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace PresentationConsole.Scenarios.Registration;

public class RegistrationScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public RegistrationScenarioProvider(IUserService userService, ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is not null || _currentUser.Administrator is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new RegistrationScenario(_userService);
        return true;
    }
}