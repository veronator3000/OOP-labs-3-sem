using System.Diagnostics.CodeAnalysis;
using Contracts.Transactions;
using Contracts.Users;

namespace PresentationConsole.Scenarios.IncreaseMoney;

public class IncreaseMoneyScenarioProvider : IScenarioProvider
{
    private readonly IUserService _user;
    private readonly ITransactionService _transaction;
    private readonly ICurrentUserService _currentUser;

    public IncreaseMoneyScenarioProvider(
        IUserService user,
        ITransactionService transaction,
        ICurrentUserService currentUser)
    {
        _user = user;
        _transaction = transaction;
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

        scenario = new IncreaseMoneyScenario(_user, _transaction);
        return true;
    }
}