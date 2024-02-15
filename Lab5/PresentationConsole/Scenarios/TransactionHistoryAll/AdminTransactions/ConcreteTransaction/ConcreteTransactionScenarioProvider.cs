using System.Diagnostics.CodeAnalysis;
using Contracts.Transactions;
using Contracts.Users;

namespace PresentationConsole.Scenarios.TransactionHistoryAll.AdminTransactions.ConcreteTransaction;

public class ConcreteTransactionScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;
    private readonly ITransactionService _transaction;

    public ConcreteTransactionScenarioProvider(
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

        scenario = new ConcreteTransactionScenario(_transaction);
        return true;
    }
}