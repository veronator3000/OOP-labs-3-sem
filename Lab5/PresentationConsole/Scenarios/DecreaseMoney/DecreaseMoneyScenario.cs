using ApplicationMain.Exceptions;
using Contracts.Transactions;
using Contracts.Users;
using Models.Transactions;
using Spectre.Console;

namespace PresentationConsole.Scenarios.DecreaseMoney;

public class DecreaseMoneyScenario : IScenario
{
    private readonly IUserService _user;
    private readonly ITransactionService _transaction;

    public DecreaseMoneyScenario(
        IUserService user,
        ITransactionService transaction)
    {
        _user = user;
        _transaction = transaction;
    }

    public string Name => "Withdraw money";
    public async Task Run()
    {
        long amount = AnsiConsole.Ask<long>("enter amount");
        DecreaseMoneyResult result = await _user.DecreaseMoney(amount);
        string message = result switch
        {
            DecreaseMoneyResult.Success => UpdateTransactionAndReturnMessage(TransactionType.IncreaseInvoiceAmount, amount),
            DecreaseMoneyResult.Failed => "not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        return;
    }

    private string UpdateTransactionAndReturnMessage(TransactionType transactionType, long amount)
    {
        try
        {
            _transaction.UpdateTransactionCashWithdrawal(transactionType, amount);
            return "success transaction";
        }
        catch (CurrentUserNullException)
        {
            return "system problem";
        }
    }
}