using Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> FindByUsername(string username);
    Task<RegistrationResult> AddUser(User user);
    Task<long> GetBalance(string username);
    Task<DecreaseMoneyResult> CashWithdrawal(string username, long amount);
    Task<IncreaseMoneyResult> AddingMoney(string username, long amount);
    Task<User?> SignIn(string username, string password);
}