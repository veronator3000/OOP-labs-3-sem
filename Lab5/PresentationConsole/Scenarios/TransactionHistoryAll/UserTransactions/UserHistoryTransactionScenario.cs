using System.Globalization;
using ApplicationMain.Exceptions;
using Contracts.Transactions;
using Models.Transactions;
using Spectre.Console;

namespace PresentationConsole.Scenarios.TransactionHistoryAll.UserTransactions;

public class UserHistoryTransactionScenario : IScenario
{
    private readonly ITransactionService _transaction;

    public UserHistoryTransactionScenario(ITransactionService transaction)
    {
        _transaction = transaction;
    }

    public string Name => "See transaction history";
    public async Task Run()
    {
        try
        {
            IList<TransactionHistory> history = await _transaction.GetTransaction();
            foreach (TransactionHistory temp in history)
            {
                string transactionTypeString = temp.TypeOfTransaction.ToString();
                AnsiConsole.WriteLine(
                    transactionTypeString + ' ' + temp.BalanceAmount.ToString(CultureInfo.InvariantCulture));
            }
        }
        catch (CurrentUserNullException)
        {
            AnsiConsole.WriteLine("system problem");
        }
    }
}
