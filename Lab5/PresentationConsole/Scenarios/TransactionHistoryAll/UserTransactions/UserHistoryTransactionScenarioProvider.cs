using System.Diagnostics.CodeAnalysis;
using Contracts.Transactions;
using Contracts.Users;

namespace PresentationConsole.Scenarios.TransactionHistoryAll.UserTransactions;

public class UserHistoryTransactionScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;
    private readonly ITransactionService _transaction;

    public UserHistoryTransactionScenarioProvider(
        ICurrentUserService currentUser,
        ITransactionService transaction)
    {
        _currentUser = currentUser;
        _transaction = transaction;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserHistoryTransactionScenario(_transaction);
        return true;
    }
}