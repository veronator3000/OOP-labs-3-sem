using System.Globalization;
using Contracts.Transactions;
using Models.Transactions;
using Spectre.Console;

namespace PresentationConsole.Scenarios.TransactionHistoryAll.AdminTransactions.ConcreteTransaction;

public class ConcreteTransactionScenario : IScenario
{
    private readonly ITransactionService _transaction;

    public ConcreteTransactionScenario(ITransactionService transaction)
    {
        _transaction = transaction;
    }

    public string Name => "Get someones transaction history";
    public async Task Run()
    {
        long id = AnsiConsole.Ask<long>("enter id user u want to see");
        IList<TransactionHistory> history = await _transaction.GetTransaction(id);
        foreach (TransactionHistory temp in history)
        {
            string transactionTypeString = temp.TypeOfTransaction.ToString();
            AnsiConsole.WriteLine(
                transactionTypeString + ' ' + temp.BalanceAmount.ToString(CultureInfo.InvariantCulture));
        }

        return;
    }
}