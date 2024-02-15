using System.Globalization;
using Contracts.Administrators;
using Contracts.Users;
using Spectre.Console;

namespace PresentationConsole.Scenarios.Balance.BalanceAdmin;

public class BalanceAdminScenario : IScenario
{
    private readonly IAdminService _adminService;
    private readonly IUserService _userService;

    public BalanceAdminScenario(
        IAdminService adminService,
        IUserService userService)
    {
        _adminService = adminService;
        _userService = userService;
    }

    public string Name => "Check users balance";
    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("enter username");
        long result = await _userService.CheckBalance(username);
        string balanceString = result.ToString(CultureInfo.InvariantCulture);
        AnsiConsole.WriteLine(balanceString);
        return;
    }
}