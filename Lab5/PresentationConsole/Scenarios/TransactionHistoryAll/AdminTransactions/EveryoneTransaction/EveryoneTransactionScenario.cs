using System.Globalization;
using Contracts.Transactions;
using Models.Transactions;
using Spectre.Console;

namespace PresentationConsole.Scenarios.TransactionHistoryAll.AdminTransactions.EveryoneTransaction;

public class EveryoneTransactionScenario : IScenario
{
    private readonly ITransactionService _transaction;

    public EveryoneTransactionScenario(ITransactionService transaction)
    {
        _transaction = transaction;
    }

    public string Name => "Get transactions of all users";
    public async Task Run()
    {
        IList<TransactionHistory> history = await _transaction.GetAllTransaction();
        foreach (TransactionHistory temp in history)
        {
            string transactionTypeString = temp.TypeOfTransaction.ToString();
            AnsiConsole.WriteLine(
                "user_id: "
                + temp.Id.ToString(CultureInfo.InvariantCulture)
                + ' ' + transactionTypeString
                + ' ' + temp.BalanceAmount.ToString(CultureInfo.InvariantCulture));
        }

        return;
    }
}