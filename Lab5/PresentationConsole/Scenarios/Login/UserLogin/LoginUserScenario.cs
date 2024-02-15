using Contracts.Users;
using Spectre.Console;

namespace PresentationConsole.Scenarios.Login.UserLogin;

public class LoginUserScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginUserScenario(
        IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login User";
    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string password = AnsiConsole.Ask<string>("Enter your password");
        LoginResult userResult = await _userService.SignIn(username, password);
        string message = userResult switch
        {
            LoginResult.UserSuccess => "Successful login",
            LoginResult.UserNotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(userResult)),
        };
        AnsiConsole.WriteLine(message);
        return;
    }
}