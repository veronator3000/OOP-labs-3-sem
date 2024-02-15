namespace Contracts.Users;

public interface IUserService
{
    Task<LoginResult> SignIn(string username, string password);
    Task<RegistrationResult> Register(string username, string password);
    Task<long> CheckBalance();
    Task<long> CheckBalance(string username);
    Task<DecreaseMoneyResult> DecreaseMoney(long amount);
    Task<IncreaseMoneyResult> IncreaseMoney(long amount);
}