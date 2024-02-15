using Models.Transactions;

namespace Abstractions.Repositories;

public interface ITransactionRepository
{
    Task<IList<TransactionHistory>> GetTransactionHistory(long userId);
    Task<IList<TransactionHistory>> GetAllTransaction();
    Task UpdateTransactionIncreaseMoney(long id, TransactionType transactionType, long amount);
    Task UpdateTransactionCashWithdrawal(long id, TransactionType transactionType, long amount);
}