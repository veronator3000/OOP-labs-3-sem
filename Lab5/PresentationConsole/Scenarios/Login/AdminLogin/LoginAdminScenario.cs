using Contracts.Administrators;
using Contracts.Users;
using Spectre.Console;

namespace PresentationConsole.Scenarios.Login.AdminLogin;

public class LoginAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LoginAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login Admin";
    public async Task Run()
    {
        string adminPassword = AnsiConsole.Ask<string>("enter secret-super-duper-mega-ultra password");
        LoginResult getAccessResult = await _adminService.Login(adminPassword);
        string message = getAccessResult switch
        {
            LoginResult.AdminSuccess => "welcome admin",
            LoginResult.AdminNotFound => "you are not an admin",
            _ => throw new ArgumentOutOfRangeException(nameof(getAccessResult)),
        };
        AnsiConsole.WriteLine(message);
        return;
    }
}