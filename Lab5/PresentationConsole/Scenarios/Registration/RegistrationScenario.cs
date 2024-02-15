using Contracts.Users;
using Spectre.Console;

namespace PresentationConsole.Scenarios.Registration;

public class RegistrationScenario : IScenario
{
    private readonly IUserService _userService;

    public RegistrationScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Sign Up";
    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your login");
        string password = AnsiConsole.Ask<string>("Enter your password");
        RegistrationResult registrationResult = await _userService.Register(username, password);
        string message = registrationResult switch
        {
            RegistrationResult.SuccessRegistration => "welcome",
            RegistrationResult.CollisionPasswords => "password taken",
            RegistrationResult.CollisionUsernames => "login taken",
            RegistrationResult.FailureRegistration => "literally big problems",
            _ => throw new ArgumentOutOfRangeException(nameof(registrationResult)),
        };
        AnsiConsole.WriteLine(message);
        return;
    }
}