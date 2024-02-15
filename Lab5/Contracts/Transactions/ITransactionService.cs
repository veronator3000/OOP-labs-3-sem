using Models.Transactions;

namespace Contracts.Transactions;

public interface ITransactionService
{
    Task<IList<TransactionHistory>> GetTransaction(long id);
    Task<IList<TransactionHistory>> GetTransaction();
    Task<IList<TransactionHistory>> GetAllTransaction();
    Task UpdateTransactionCashWithdrawal(TransactionType transactionType, long amount);
    Task UpdateTransactionIncreaseMoney(TransactionType transactionType, long amount);
}