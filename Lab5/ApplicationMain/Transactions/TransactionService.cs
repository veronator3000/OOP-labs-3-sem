using Abstractions.Repositories;
using ApplicationMain.Exceptions;
using Contracts.Transactions;
using Contracts.Users;
using Models.Transactions;

namespace ApplicationMain.Transactions;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public TransactionService(
        ITransactionRepository repository,
        ICurrentUserService currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<IList<TransactionHistory>> GetTransaction(long id)
    {
        return await _repository.GetTransactionHistory(id);
    }

    public async Task<IList<TransactionHistory>> GetTransaction()
    {
        if (_currentUser.User is null)
        {
            throw new CurrentUserNullException();
        }

        return await _repository.GetTransactionHistory(_currentUser.User.Id);
    }

    public async Task<IList<TransactionHistory>> GetAllTransaction()
    {
        return await _repository.GetAllTransaction();
    }

    public async Task UpdateTransactionCashWithdrawal(TransactionType transactionType, long amount)
    {
        if (_currentUser.User is null)
        {
            throw new CurrentUserNullException();
        }

        await _repository.UpdateTransactionCashWithdrawal(_currentUser.User.Id, transactionType, amount);
    }

    public async Task UpdateTransactionIncreaseMoney(TransactionType transactionType, long amount)
    {
        if (_currentUser.User is null)
        {
            throw new CurrentUserNullException();
        }

        await _repository.UpdateTransactionIncreaseMoney(_currentUser.User.Id, transactionType, amount);
    }
}