using System.Diagnostics.CodeAnalysis;
using Contracts.Transactions;
using Contracts.Users;

namespace PresentationConsole.Scenarios.TransactionHistoryAll.AdminTransactions.EveryoneTransaction;

public class EveryoneTransactionScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;
    private readonly ITransactionService _transaction;

    public EveryoneTransactionScenarioProvider(
        ICurrentUserService currentUser,
        ITransactionService transaction)
    {
        _currentUser = currentUser;
        _transaction = transaction;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentUser.Administrator is null)
        {
            scenario = null;
            return false;
        }

        scenario = new EveryoneTransactionScenario(_transaction);
        return true;
    }
}