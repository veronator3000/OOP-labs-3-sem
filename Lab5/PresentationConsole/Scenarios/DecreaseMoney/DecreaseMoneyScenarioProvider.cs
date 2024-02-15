using System.Diagnostics.CodeAnalysis;
using Contracts.Transactions;
using Contracts.Users;

namespace PresentationConsole.Scenarios.DecreaseMoney;

public class DecreaseMoneyScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;
    private readonly ITransactionService _transactionService;

    public DecreaseMoneyScenarioProvider(
        IUserService userService,
        ICurrentUserService currentUser,
        ITransactionService transactionService)
    {
        _userService = userService;
        _currentUser = currentUser;
        _transactionService = transactionService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new DecreaseMoneyScenario(_userService, _transactionService);
        return true;
    }
}