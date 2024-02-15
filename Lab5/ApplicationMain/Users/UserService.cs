using Abstractions.Repositories;
using ApplicationMain.Exceptions;
using Contracts.Users;
using Itmo.ObjectOrientedProgramming.Lab5.Models.Users;

namespace ApplicationMain.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUser;
    public UserService(
        IUserRepository repository,
        CurrentUserManager currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<LoginResult> SignIn(string username, string password)
    {
        User? user = await _repository.SignIn(username, password);
        if (user is not null)
        {
            _currentUser.User = user;
            return new LoginResult.UserSuccess();
        }

        return new LoginResult.UserNotFound();
    }

    public async Task<RegistrationResult> Register(string username, string password)
    {
        User? existingUser = await _repository.FindByUsername(username);
        if (existingUser is not null)
        {
            return new RegistrationResult.FailureRegistration();
        }

        var newUser = new User(1, username, password, new UserBalance(0));
        RegistrationResult registrationSuccessful = await _repository.AddUser(newUser);
        _currentUser.User = newUser;

        return registrationSuccessful;
    }

    public async Task<long> CheckBalance()
    {
        if (_currentUser.User is null)
        {
            throw new CurrentUserNullException();
        }

        long temp = await _repository.GetBalance(_currentUser.User.Username);
        return temp;
    }

    public async Task<long> CheckBalance(string username)
    {
        long temp = await _repository.GetBalance(username);
        return temp;
    }

    public async Task<DecreaseMoneyResult> DecreaseMoney(long amount)
    {
        if (_currentUser.User is null)
        {
            return new DecreaseMoneyResult.Failed();
        }

        if (_currentUser.User.Balance.Balance < amount)
        {
            return new DecreaseMoneyResult.Failed();
        }

        _currentUser.User.Balance.UpdateBalance(-amount);
        DecreaseMoneyResult temp = await _repository.CashWithdrawal(_currentUser.User.Username, amount);

        return temp;
    }

    public async Task<IncreaseMoneyResult> IncreaseMoney(long amount)
    {
        if (_currentUser.User is null)
        {
            return new IncreaseMoneyResult.Failed();
        }

        _currentUser.User.Balance.UpdateBalance(amount);
        IncreaseMoneyResult temp =
            await _repository.AddingMoney(_currentUser.User.Username, amount);
        return temp;
    }
}