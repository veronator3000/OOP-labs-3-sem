using ApplicationMain.Exceptions;
using Contracts.Transactions;
using Contracts.Users;
using Models.Transactions;
using Spectre.Console;

namespace PresentationConsole.Scenarios.IncreaseMoney;

public class IncreaseMoneyScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly ITransactionService _transaction;

    public IncreaseMoneyScenario(
        IUserService userService,
        ITransactionService transactionService)
    {
        _userService = userService;
        _transaction = transactionService;
    }

    public string Name => "Top up your balance";
    public async Task Run()
    {
        long amount = AnsiConsole.Ask<long>("enter amount");
        IncreaseMoneyResult resultOperation = await _userService.IncreaseMoney(amount);
        string message = resultOperation switch
        {
            IncreaseMoneyResult.Success => UpdateTransactionAndReturnMessage(TransactionType.IncreaseInvoiceAmount, amount),
            IncreaseMoneyResult.Failed => "negative amount",
            _ => throw new ArgumentOutOfRangeException(nameof(resultOperation)),
        };

        AnsiConsole.WriteLine(message);
        return;
    }

    private string UpdateTransactionAndReturnMessage(TransactionType transactionType, long amount)
    {
        try
        {
            _transaction.UpdateTransactionIncreaseMoney(transactionType, amount);
            return "success transaction";
        }
        catch (CurrentUserNullException)
        {
            return "problem system";
        }
    }
}