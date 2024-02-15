using System.Globalization;
using ApplicationMain.Exceptions;
using Contracts.Users;
using Spectre.Console;

namespace PresentationConsole.Scenarios.Balance.BalanceUser;

public class BalanceUserScenario : IScenario
{
    private readonly IUserService _user;

    public BalanceUserScenario(IUserService user)
    {
        _user = user;
    }

    public string Name => "Check my balance";
    public async Task Run()
    {
        try
        {
            long result = await _user.CheckBalance();
            string balanceString = result.ToString(CultureInfo.InvariantCulture);
            AnsiConsole.WriteLine(balanceString);
        }
        catch (CurrentUserNullException)
        {
            AnsiConsole.WriteLine("system problem");
        }
    }
}